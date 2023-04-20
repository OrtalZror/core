
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using   שיעור_2.Utilities;
using  שיעור_2.Interfaces;
using System.IO;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace שיעור_2.Services;
public static class TokenService
    {
        
    //  public static List<User>listUsers=new List<User>{new User("123","admin","ortal","123"),new User("123","user","tami","123")};
        private static SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
        private static string issuer = "https://task-demo.com";
        public static SecurityToken GetToken(List<Claim> claims) =>
            new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

        public static TokenValidationParameters GetTokenValidationParameters() =>
            new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ")),
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };
        public static string WriteToken(SecurityToken token) =>
            new JwtSecurityTokenHandler().WriteToken(token);

 public static string DecodeToken(string token)
    {
        token=token.Split(" ")[1];
        var handler=new JwtSecurityTokenHandler();
        var decodeValue=handler.ReadJwtToken(token)as JwtSecurityToken;
        var id=decodeValue.Claims.First(claim=>claim.Type=="Id").Value;
        return id;
    }   
    
     

}