using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Dtos.Clients;
using Shop.Models;
using Shop.Services;

[ApiController]
[Route("api/[controller]")]

public class ClientsController : Controller
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("birthdays")]
    public async Task<ActionResult<List<BirthdayClientDto>>> GetBirthdays([FromQuery] DateTime date)
    {
        Console.WriteLine($"[LOG] GetBirthdays called with date: {date}");
        var result = await _clientService.GetBirthdayClientsAsync(date);
        Console.WriteLine($"[LOG] Clients found: {result.Count}");
        return Ok(result);
    }

    [HttpGet("recent-buyers")]
    public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
    {
        var result = await _clientService.GetRecentBuyersAsync(days);
        return Ok(result);
    }

    [HttpGet("clients/{clientId}/categories")]
    public async Task<IActionResult> GetClientCategories(int clientId)
    {
        try
        {
            var result = await _clientService.GetCategoriesByClientIdAsync(clientId);
            if (result == null || result.Count == 0)
                return NotFound("Клієнт не має куплених категорій.");

            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }


}

