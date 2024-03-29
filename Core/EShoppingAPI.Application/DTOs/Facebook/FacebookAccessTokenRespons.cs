﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.DTOs.Facebook
{
    public class FacebookAccessTokenRespons
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("access_type")]
        public string TokenType { get; set; }
    }
}
