using System;

namespace Model.Dto
{
    public  class PedidoItemFornecedorDto
    {
        public int PedidoItemFornecedorId { get; set; }
        public string CodPedidoItemFornec { get; set; }
        public int PedidoItemId { get; set; }
        public int FornecedorId { get; set; }
        public int StatusId { get; set; }
        public string StatusNome { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public string Observacao { get; set; }
    }
}
