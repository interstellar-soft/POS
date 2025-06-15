using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.API.Data;
using POS.API.Models;

using Microsoft.AspNetCore.Identity;
namespace POS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<User> _userManager;

    public SalesController(ApplicationDbContext db, UserManager<User> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaleDto dto)
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        if (user == null) return Unauthorized();

        var sale = new Sale { UserId = user.Id, TotalUSD = dto.TotalUSD, TotalLBP = dto.TotalLBP };
        _db.Sales.Add(sale);
        await _db.SaveChangesAsync();
        foreach (var item in dto.Items)
        {
            _db.SaleItems.Add(new SaleItem
            {
                SaleId = sale.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                PriceUSD = item.PriceUSD,
                PriceLBP = item.PriceLBP
            });
        }
        await _db.SaveChangesAsync();
        return Ok(sale);
    }
}

public record SaleItemDto(int ProductId, int Quantity, decimal PriceUSD, decimal PriceLBP);
public record SaleDto(decimal TotalUSD, decimal TotalLBP, List<SaleItemDto> Items);
