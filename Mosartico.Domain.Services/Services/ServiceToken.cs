using Microsoft.IdentityModel.Tokens;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public static class ServiceToken
    {
        public static string GenerateToken(Usuario user, bool resetSenha = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, user.Perfil.Tipo.ToString())
                }),
                Expires = !resetSenha ? DateTime.UtcNow.AddHours(6) : DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }
    }
}
