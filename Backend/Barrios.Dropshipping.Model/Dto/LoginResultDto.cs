using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
   public class LoginResultDto
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }
    }
}
