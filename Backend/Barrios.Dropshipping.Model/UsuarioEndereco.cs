using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("UsuarioEndereco", Schema = "dbo")]
    public class UsuarioEndereco
    {
        public int UsuarioEnderecoId { get; set; }
        public int UsuarioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
