using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.API.Models;

[Table("Comments")]
public class Comment
{
    public int Id { get; set; }
    [MaxLength(255)] public string Title { get; set; } = string.Empty;
    [MaxLength(4000)] public string Content { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    // by convention EntityFrameworkCore(ORM) will use the name of the class as the table name
    public int StockId { get; set; }
    public required string UserId { get; set; }

    // Navigation property
    public Stock? Stock { get; set; }
    public User? User { get; set; }
}
