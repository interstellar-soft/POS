using System.ComponentModel.DataAnnotations;

namespace POS.API.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; }
}
