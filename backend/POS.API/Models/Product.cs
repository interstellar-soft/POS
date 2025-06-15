using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.API.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(50)]
    public string? SKU { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    [Precision(18,2)]
    public decimal PriceUSD { get; set; }

    [Precision(18,2)]
    public decimal PriceLBP { get; set; }

    public ICollection<SaleItem>? SaleItems { get; set; }
}
