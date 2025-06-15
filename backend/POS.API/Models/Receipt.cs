using System.ComponentModel.DataAnnotations;

namespace POS.API.Models;

public class Receipt
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public Sale? Sale { get; set; }

    [StringLength(100)]
    public string Number { get; set; } = string.Empty;
}
