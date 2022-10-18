using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class HomeController : Controller
    {
        ApplicationDBContext dBContext;

        public HomeController(ApplicationDBContext dB)
        {
            this.dBContext = dB;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = dBContext.Books.ToListAsync() });
        }
    }
}
