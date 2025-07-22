using Shop.Dtos.Clients;
using Shop.Models;

namespace Shop.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsByBirthdayAsync(DateTime date);
        Task<List<RecentBuyerDto>> GetRecentBuyersAsync(int days);
        Task<List<CategoryStatsDto>> GetClientProductCategoriesAsync(int clientId);
    }
}
