using System.Threading.Tasks;
using Web2021B.Data.Model;

namespace Web2021B.Data.Service
{
    public interface IClienteService
    {
        Task<bool> ClienteInsert(Cliente cliente);
    }
}