using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
namespace POS.API.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Precision(18,2)]
    public decimal TotalUSD { get; set; }

    [Precision(18,2)]
    public decimal TotalLBP { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public ICollection<SaleItem>? Items { get; set; }
}
