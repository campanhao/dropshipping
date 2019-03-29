using Barrios.Fornecedores.Communication;
using Barrios.Fornecedores.Model;
using System.Configuration;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Barrios.Fornecedores
{
    public class AtualizarStatusService : IAtualizarStatusService
    {
        private readonly RestServiceBase service;

        public AtualizarStatusService()
        {
            service = new RestServiceBase();
        }
        public async Task<string> AtualizarStatusAsync(string codPedidoItemFornec, int status)
        {
            var jwt = await GetToken();

            var obj = new
            {
                codPedidoFornec = codPedidoItemFornec,
                status = status
            };
            var url = string.Concat(ConfigurationManager.AppSettings.Get("urlStore"), "pedidos/atualizar");
            return await Task.FromResult<string>(await service.PostAsync<object, string>(url, obj, jwt));
        }

        private async Task<string> GetToken()
        {
            var usuario = ConfigurationManager.AppSettings.Get("usuario");
            var senha = ConfigurationManager.AppSettings.Get("senha");
            LoginRequest request = new LoginRequest()
            {
                Usuario = usuario,
                Senha = senha
            };
            var url = string.Concat(ConfigurationManager.AppSettings.Get("urlStore"), "logins/fornecedor");
            return await service.PostAsync<object, string>(url, request, "");
        }
    }
}
