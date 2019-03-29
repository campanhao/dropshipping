using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
   public class PedidoItemRequestDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
