using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TokenBusiness : ITokenBusiness
    {
        private readonly IUsuarioBusiness _clienteBusiness;

        private IConfiguration _configuration { get; }

        public TokenBusiness(IUsuarioBusiness clienteBusiness, IConfiguration configuration)
        {
            _clienteBusiness = clienteBusiness;
            _configuration = configuration;
        }

        public async Task<string> LoginUsuario(Usuario usuario, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("nome", usuario.Nome),
                        new Claim(ClaimTypes.Role, "usuario"),
                        new Claim("id", usuario.UsuarioId.ToString()),
                    }
                );
            return await GenerateJwt(tokenConfigurations, signingConfigurations, identity);
        }
        public async Task<string> LoginFornecedor(Fornecedor fornecedor, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(fornecedor.Usuario, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("nome", fornecedor.Nome),
                        new Claim(ClaimTypes.Role, "fornecedor"),
                        new Claim("id", fornecedor.FornecedorId.ToString()),
                    }
                );
            return await GenerateJwt(tokenConfigurations, signingConfigurations, identity);
        }

        private async Task<string> GenerateJwt(TokenConfigurations tokenConfiguration, SigningConfigurations signingConfigurations, ClaimsIdentity identity)
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromMinutes(tokenConfiguration.Minutes);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfiguration.Issuer,
                Audience = tokenConfiguration.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            return await Task.Run(() => handler.WriteToken(securityToken));
        }
    }

}
