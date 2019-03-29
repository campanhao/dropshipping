using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Fornecedor", Schema = "dbo")]
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<PedidoItemFornecedor> PedidoFornecedores { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
