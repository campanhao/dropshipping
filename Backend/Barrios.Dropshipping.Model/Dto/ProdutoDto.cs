using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
  public  class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string CodProdFornec { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}
