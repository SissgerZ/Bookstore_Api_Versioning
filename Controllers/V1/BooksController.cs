using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers.V1;

[Route("api/v{version}/books")]
[ApiController]
[ApiVersion("1.0")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public ActionResult<Models.V1.Book> GetBook()
    {
        return new Models.V1.Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Price = 45.99M
        };
    }
}
