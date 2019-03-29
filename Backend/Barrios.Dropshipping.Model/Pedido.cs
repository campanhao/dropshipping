using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Pedido", Schema = "dbo")]
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public int FormaPagamentoId { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public virtual PedidoEntrega PedidoEntrega { get; set; }
        public virtual ICollection<PedidoItem> PedidoItens { get; set; }

    }
}
