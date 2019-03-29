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
    public class UsuarioEnderecoBusiness : Repository<UsuarioEndereco>, IUsuarioEnderecoBusiness
    {
        #region Atributos
        private readonly IUsuarioEnderecoRepository _usuarioEnderecoRepository;
        #endregion

        #region Construtores
        public UsuarioEnderecoBusiness(IUsuarioEnderecoRepository usuarioEnderecoRepository, Context context)
            :base(context)
        {
            _usuarioEnderecoRepository = usuarioEnderecoRepository;
        }
        #endregion

        #region Métodos Públicos
        #endregion
    }
}
