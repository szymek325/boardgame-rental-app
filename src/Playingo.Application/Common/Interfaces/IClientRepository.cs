using System.Threading.Tasks;
using Playingo.Domain.Clients;

namespace Playingo.Application.Common.Interfaces
{
    public interface IClientRepository
    {
        Task AddASync(Client client);
    }
}