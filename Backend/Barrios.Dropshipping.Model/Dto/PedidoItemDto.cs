using System.Collections.Generic;

namespace Model.Dto
{
    public  class PedidoItemDto
    {
        public int PedidoItemId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public  PedidoItemFornecedorDto PedidoItemFornecedor { get; set; }

    }
}
