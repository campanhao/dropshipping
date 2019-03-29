using AutoMapper;
using DAL;
using DAL.Interfaces;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBusiness : Repository<Usuario>, IUsuarioBusiness
    {
        #region Atributos
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public UsuarioBusiness(IUsuarioRepository usuarioRepository, Context context, IMapper mapper)
            :base(context)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public async Task<Usuario> Get(UsuarioRequestDto requisicaoLogin)
        {
            var pin = Convert.ToBase64String((Encoding.UTF8.GetBytes(requisicaoLogin.Senha)));
            var usuario = await Task.Run(() => _usuarioRepository.Get(x => x.Email == requisicaoLogin.Email && x.Senha == pin));
            return usuario;
        }
        public async Task<IEnumerable<UsuarioEnderecoDto>> GetListAsync(int usuarioId)
        {
            var enderecos = new List<UsuarioEnderecoDto>();
            var usuario = await _usuarioRepository.GetAsync(usuarioId);

            foreach(var endereco in usuario.UsuarioEnderecos)
            {
                var texto = new StringBuilder();
                texto.AppendLine(string.Concat(endereco.Logradouro, ", ", endereco.Numero," ",endereco.Complemento,"<br>"));
                texto.AppendLine(string.Concat(endereco.Bairro, ", ", endereco.Cidade," ",endereco.Estado, "<br>"));
                texto.AppendLine(string.Concat(endereco.CEP));

                enderecos.Add(new UsuarioEnderecoDto()
                {
                    UsuarioEnderecoId = endereco.UsuarioEnderecoId,
                    Endereco = texto.ToString()
                });
            }
            return enderecos;         
        }
        #endregion
    }
}
