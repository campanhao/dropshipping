using Barrios.Dropshipping.Api.Controllers.Base;
using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dto;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class LoginsController : BaseController
    {
        private readonly ITokenBusiness _tokenBusiness;
        private readonly IFornecedorBusiness _fornecedorBusiness;
        private readonly IUsuarioBusiness _usuarioBusiness;

        public LoginsController(IUsuarioBusiness usuarioBusiness, IFornecedorBusiness fornecedorBusiness, ITokenBusiness tokenBusiness)
        {
            _tokenBusiness = tokenBusiness;
            _usuarioBusiness = usuarioBusiness;
            _fornecedorBusiness = fornecedorBusiness;
        }

        [HttpPost]
        [Route("usuario")]
        public async Task<object> LoginUsuarioAsync(
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations,
            [FromBody] UsuarioRequestDto requisicaoLogin)
        {
            try
            {
                var usuario = await _usuarioBusiness.Get(requisicaoLogin);

                if (usuario != null)
                {
                    var result = await _tokenBusiness.LoginUsuario(usuario, signingConfigurations, tokenConfigurations);
                    return Ok(result);
                }
                else
                {
                    return StatusCode(403, "Login inválido");
                }
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("fornecedor")]
        public async Task<object> LoginFornecedorAsync(
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations,
            [FromBody] FornecedorRequestDto requisicaoLogin)
        {
            try
            {
                var fornecedor = await _fornecedorBusiness.Get(requisicaoLogin);

                if (fornecedor != null)
                {
                    var result = await _tokenBusiness.LoginFornecedor(fornecedor, signingConfigurations, tokenConfigurations);
                    return Ok(result);
                }
                else
                {
                    return StatusCode(403, "Login inválido");
                }
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}