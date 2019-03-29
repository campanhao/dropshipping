using Barrios.Dropshipping.Api.Controllers.Base;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaBusiness _categoriaBusiness;

        public CategoriasController(ICategoriaBusiness categoriaBusiness)
        {
            _categoriaBusiness = categoriaBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _categoriaBusiness.GetListAsync());
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
