using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
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
    }
}
