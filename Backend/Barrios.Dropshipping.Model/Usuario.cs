using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Usuario", Schema = "dbo")]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<UsuarioEndereco> UsuarioEnderecos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}
