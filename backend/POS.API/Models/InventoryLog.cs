using System.ComponentModel.DataAnnotations;

namespace POS.API.Models;

public class InventoryLog
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
