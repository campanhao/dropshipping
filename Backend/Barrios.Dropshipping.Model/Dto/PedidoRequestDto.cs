using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
   public class PedidoRequestDto
    {
        public decimal ValorTotal { get; set; }
        public int FormaPagamentoId { get; set; }
        public int UsuarioEnderecoId { get; set; }
        public IEnumerable<PedidoItemRequestDto> Itens { get; set; }
    }
}
