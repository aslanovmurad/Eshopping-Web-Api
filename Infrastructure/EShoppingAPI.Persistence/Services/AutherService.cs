using Azure.Core;
using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.Abstraction.Token;
using EShoppingAPI.Application.DTOs;
using EShoppingAPI.Application.DTOs.Facebook;
using EShoppingAPI.Application.Exceptions;
using EShoppingAPI.Application.Helpers;
using EShoppingAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Services
{
    public class AutherService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly HttpClient _httpClient;
        readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;
        readonly IMailService _mailService;
        public AutherService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService, IMailService mailService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }

        async Task<Token> CreateUserExternalAsync(AppUser user, string email, string name, UserLoginInfo info, int accessTokenLifeTime)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        NameSurName = name
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(user, info);
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 5);
                return token;
            }
            throw new Exception("Invalid Externam authentication");
        }


        public async Task<Token> FacebookLoginAsync(string AuthToken, int accessTokenLifeTime)
        {
            string accesTokenRespons = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalLoginSetting:Facebook:client_id"]}&client_secret={_configuration["ExternalLoginSetting:Facebook:client_secret"]}&grant_type=client_credentials");

            FacebookAccessTokenRespons? facebookAccessTokenRespons_DTO = JsonSerializer.Deserialize<FacebookAccessTokenRespons>(accesTokenRespons);
            string useraccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={AuthToken}&access_token={facebookAccessTokenRespons_DTO?.AccessToken}");

            FacebookUserAccessTokenValidation? validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(useraccessTokenValidation);

            if (validation?.Data.IsValid != null)
            {
                string userInfoRespons = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={AuthToken}");
                FacebookUserInfoRespons? userinfo = JsonSerializer.Deserialize<FacebookUserInfoRespons>(userInfoRespons);

                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                return await CreateUserExternalAsync(user, userinfo.Email, userinfo.Name, info, accessTokenLifeTime);
            }
            throw new Exception("Invalid Externam authentication");

        }

        public async Task<Token> GoogleLoginAsync(string IdToken, int accessTokenLifeTime)
        {
            var setting = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSetting:Google:Client_ID"] }
            };

            var paylod = await GoogleJsonWebSignature.ValidateAsync(IdToken, setting);
            var info = new UserLoginInfo("GOOGLE", paylod.Subject, "GOOGLE");
            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, paylod.Email, paylod.Name, info, accessTokenLifeTime);
        }

        public async Task<Token> LoginAsync(string UserNameOrEmail, string Password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(UserNameOrEmail);
            user ??= await _userManager.FindByEmailAsync(UserNameOrEmail);
            if (user == null)
                throw new NoteFoundUserException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 5);
                return token;
            }
            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsyc(string refreshToken)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            else
                throw new NoteFoundUserException();
        }

        public async Task PasswordResetAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

               resetToken = resetToken.UrlEncode();

               await _mailService.SenPasswordResetMailAsync(email, user.Id, resetToken);
            }
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user !=null)
            {
                resetToken = resetToken.UrlDecode();

                return await  _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPasswor", resetToken);
            }
            return false;
        }
    }
}
