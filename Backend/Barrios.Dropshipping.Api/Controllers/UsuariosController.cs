using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Extensions;
using System;
using System.Threading.Tasks;
using Barrios.Dropshipping.Api.Controllers.Base;

namespace Api.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuariosController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        [Authorize("Usuario")]
        [Route("enderecos")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarioId = ExtensionsController.GetId(this);
                return Ok( await _usuarioBusiness.GetListAsync(usuarioId));
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
