using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers.V2;

[Route("api/v{version}/books")]
[ApiController]
[ApiVersion("2.0")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public ActionResult<Models.V2.Book> GetBook()
    {
        return new Models.V2.Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Price = 45.99M,
            Stock = 20 // New property in version 2
        };
    }
}
