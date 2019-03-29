using System.ServiceModel;
using System.Threading.Tasks;

namespace Barrios.Fornecedores
{
    [ServiceContract]
    public interface IAtualizarStatusService
    {
        [OperationContract]
        Task<string> AtualizarStatusAsync(string codPedidoItemFornec, int status);
    }
}
