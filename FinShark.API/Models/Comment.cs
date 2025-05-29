namespace FinShark.API.Models;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    // by convention EntityFrameworkCore will use the name of the class as the table name
    public int? StockId { get; set; }

    // Navigation property
    public Stock? Stock { get; set; }
}