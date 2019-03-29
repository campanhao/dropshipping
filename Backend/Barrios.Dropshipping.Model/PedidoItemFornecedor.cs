using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("PedidoItemFornecedor", Schema = "dbo")]
    public class PedidoItemFornecedor
    {
        public int PedidoItemFornecedorId { get; set; }
        public string CodPedidoItemFornec { get; set; }
        public int PedidoItemId { get; set; }
        public int FornecedorId { get; set; }
        public int StatusId { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public string Observacao { get; set; }

        public virtual Status Status { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual PedidoItem PedidoItem { get; set; }

    }
}
