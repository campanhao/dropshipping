using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Api.Controllers.Extensions;
using System;
using System.Threading.Tasks;
using Barrios.Dropshipping.Api.Controllers.Base;

namespace Api.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PedidosController : BaseController
    {
        private readonly IPedidoBusiness _pedidoBusiness;
        private readonly IPedidoItemFornecedorBusiness _pedidoItemFornecedorBusiness;

        public PedidosController(IPedidoBusiness pedidoBusiness, IPedidoItemFornecedorBusiness pedidoItemFornecedorBusiness)
        {
            _pedidoBusiness = pedidoBusiness;
            _pedidoItemFornecedorBusiness = pedidoItemFornecedorBusiness;
        }

        [Authorize(Policy = "Usuario")]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var id = ExtensionsController.GetId(this);
                var pedidos = await _pedidoBusiness.GetAsync(id);
                return Ok(pedidos);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Policy = "Usuario")]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PedidoRequestDto dto)
        {
            try
            {
                var id = ExtensionsController.GetId(this);
                await _pedidoBusiness.PostAsync(dto, id);
                return Ok("Pedido efetuado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                LogarErro(ex);
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Policy = "Fornecedor")]
        [Route("atualizar")]
        [HttpPost]
        public async Task<ActionResult> AtualizarItemAsync([FromBody] PedidoItemStatusDto item)
        {
            try
            {
                var id = ExtensionsController.GetId(this);
               var pedido = await _pedidoItemFornecedorBusiness.AtualizarItemAsync(item,id);
                return Ok("Pedido " + pedido.CodPedidoItemFornec + " atualizado! Novo status: " + pedido.Status.Nome);
            }
            catch (ArgumentException ex)
            {
                LogarErro(ex);
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                LogarErro(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
