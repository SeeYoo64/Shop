using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Dtos.Clients;
using Shop.Repositories;

namespace Shop.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BirthdayClientDto>> GetBirthdayClientsAsync(DateTime date)
        {
            var clients = await _repository.GetClientsByBirthdayAsync(date);

            return clients
                .Select(c => new BirthdayClientDto
                {
                    Id = c.Id,
                    FullName = c.FullName
                })
                .ToList();
        }

        public async Task<List<RecentBuyerDto>> GetRecentBuyersAsync(int days)
        {
            return await _repository.GetRecentBuyersAsync(days);
        }

        public async Task<List<CategoryStatsDto>> GetCategoriesByClientIdAsync(int clientId)
        {
            return await _repository.GetClientProductCategoriesAsync(clientId);
        }

    }
}
