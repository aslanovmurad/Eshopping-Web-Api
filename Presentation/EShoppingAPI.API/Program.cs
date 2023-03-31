
using EShoppingAPI.Application;
using EShoppingAPI.Application.Validators;
using EShoppingAPI.Infrastructure;
using EShoppingAPI.Infrastructure.Filters;
using EShoppingAPI.Infrastructure.Services.Storage.Azure;
using EShoppingAPI.Infrastructure.Services.Storage.Local;
using EShoppingAPI.Persistence;
using EShoppingAPI.SignalR;
using EShoppingAPI.SignalR.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceService();
builder.Services.AddInfrastructureService();
builder.Services.AddApplicationServices();
builder.Services.AddSignlRServices();
//var log = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.File("logs/log.txt")
//    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), "logs", autoCreateSqlTable: true,
//   columnOptions: new ColumnOptions
//   {
//       AdditionalDataColumns = new Collection<DataColumn>
//            {
//                new DataColumn {DataType = typeof(string), ColumnName = "user_name"},
//            },
//       Store = new MSSqlServerSinkOptions
//       {
//           TableName = "logs",
//           AutoCreateSqlTable = true
//       }
//   })
//    .CreateLogger();

//builder.Host.UseSerilog(log);



builder.Services.AddStorage<LocalStorage>();
//builder.Services.AddStorage<AzureStorage>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", op =>
    {
        op.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
            NameClaimType = ClaimTypes.Name
        };
    });

builder.Services.AddCors(option => option.AddDefaultPolicy(polic =>
    polic.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
  .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProdactValidoter>())
  .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub();
app.Run();
