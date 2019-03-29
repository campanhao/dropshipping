using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("FormaPagamento", Schema = "dbo")]
    public class FormaPagamento
    {
        public int FormaPagamentoId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
