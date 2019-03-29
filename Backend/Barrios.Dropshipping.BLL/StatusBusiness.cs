using AutoMapper;
using DAL;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class StatusBusiness : Repository<Status>, IStatusBusiness
    {
        #region Atributos
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public StatusBusiness(IStatusRepository statusRepository, Context context, IMapper mapper)
            :base(context)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        #endregion
    }
}
