namespace Bookstore.Models.V2;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; } // New property in version 2
}
