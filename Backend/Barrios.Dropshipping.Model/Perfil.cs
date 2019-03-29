using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Perfil", Schema = "dbo")]
    public class Perfil
    {
        public int PerfilId { get; set; }
        public string Nome { get; set; }  
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
