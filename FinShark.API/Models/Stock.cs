using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.API.Models;

[Table("Stocks")]
public class Stock
{
    public int Id { get; set; }
    [MaxLength(20)] public string Symbol { get; set; } = string.Empty;
    [MaxLength(255)] public string CompanyName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")] public decimal Purchase { get; set; }
    [Column(TypeName = "decimal(18,2)")] public decimal LastDiv { get; set; }
    [MaxLength(100)] public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    public List<Comment> Comments { get; set; } = new();
    public List<Portfolio> Portfolios { get; set; } = new();
}