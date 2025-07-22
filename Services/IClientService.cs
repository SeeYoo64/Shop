using Shop.Dtos.Clients;

namespace Shop.Services
{
    public interface IClientService
    {
        Task<List<BirthdayClientDto>> GetBirthdayClientsAsync(DateTime date);
    }
}
