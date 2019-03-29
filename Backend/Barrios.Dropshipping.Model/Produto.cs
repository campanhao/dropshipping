using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Produto", Schema = "dbo")]
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string CodProdFornec { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public bool EmEstoque { get; set; }
        public bool Ativo { get; set; }
        public int FornecedorId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<PedidoItem> PedidoItens { get; set; }

    }
}
