using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Status", Schema = "dbo")]
    public class Status
    {
        public int StatusId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<PedidoItemFornecedor> PedidoFornecedores { get; set; }
    }
}
