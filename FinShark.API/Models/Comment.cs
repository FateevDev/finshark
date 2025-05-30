using System.ComponentModel.DataAnnotations;

namespace FinShark.API.Models;

public class Comment
{
    public int Id { get; set; }
    [MaxLength(255)] public string Title { get; set; } = string.Empty;
    [MaxLength(4000)] public string Content { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    // by convention EntityFrameworkCore(ORM) will use the name of the class as the table name
    public int? StockId { get; set; }

    // Navigation property
    public Stock? Stock { get; set; }
}
