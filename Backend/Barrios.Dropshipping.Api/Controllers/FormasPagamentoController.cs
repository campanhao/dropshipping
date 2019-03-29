using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Extensions;
using System;
using System.Threading.Tasks;
using log4net;
using Barrios.Dropshipping.Api.Controllers.Base;

namespace Api.Controllers
{

    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class FormasPagamentoController : BaseController
    {
        private readonly IFormaPagamentoBusiness _formaPagamentoBusiness;
        
        public FormasPagamentoController(IFormaPagamentoBusiness formaPagamentoBusiness)
        {
            _formaPagamentoBusiness = formaPagamentoBusiness;
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {         
            try
            {
                return Ok( await _formaPagamentoBusiness.GetListAsync());
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
