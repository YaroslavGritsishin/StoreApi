﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Domain
{
    public class AuthOptions
    {
        public string Issure { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
