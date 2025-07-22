using Shop.Models;

namespace Shop.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsByBirthdayAsync(DateTime date);
    }
}
