using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
namespace POS.API.Models;

public class SaleItem
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public Sale? Sale { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Precision(18,2)]
    public decimal PriceUSD { get; set; }

    [Precision(18,2)]
    public decimal PriceLBP { get; set; }

    public int Quantity { get; set; }
}
