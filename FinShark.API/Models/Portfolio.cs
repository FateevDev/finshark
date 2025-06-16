using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.API.Models;

[Table("Portfolios")]
public class Portfolio
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public int StockId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public User? User { get; set; }
    public Stock? Stock { get; set; }
}