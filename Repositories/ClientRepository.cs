using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Dtos.Clients;
using Shop.Models;

namespace Shop.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ShopDbContext _context;

        public ClientRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetClientsByBirthdayAsync(DateTime date)
        {
            var clients = await _context.Clients
                .Where(c => c.DateOfBirth.Month == date.Month && c.DateOfBirth.Day == date.Day)
                .ToListAsync();

            foreach (var c in clients)
            {
                Debug.WriteLine($"[LOG] Found client: {c.FullName} - {c.DateOfBirth}");
            }

            return clients;
        }


        public async Task<List<RecentBuyerDto>> GetRecentBuyersAsync(int days)
        {
            var thresholdDate = DateTime.UtcNow.Date.AddDays(-days);

            var recentBuyers = await _context.Purchases
                .Where(p => p.Date >= thresholdDate)
                .GroupBy(p => new { p.ClientId, p.Client.FullName })
                .Select(g => new RecentBuyerDto
                {
                    Id = g.Key.ClientId,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.Date)
                })
                .OrderByDescending(x => x.LastPurchaseDate)
                .ToListAsync();

            return recentBuyers;
        }

    }
}
