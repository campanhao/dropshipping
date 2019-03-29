using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Extensions;
using System;
using System.Threading.Tasks;
using Barrios.Dropshipping.Api.Controllers.Base;

namespace Api.Controllers
{

    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutosController(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok( await _produtoBusiness.GetListAsync());
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        [Route("pesquisar")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                return Ok(await _produtoBusiness.GetListAsync(nome));
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        [Route("categoria")]
        public async Task<IActionResult> Get(int categoriaId)
        {
            try
            {
                return Ok(await _produtoBusiness.GetListAsync(categoriaId));
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
