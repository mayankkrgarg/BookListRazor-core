using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> books { get; set; }
        public async Task OnGet()
        {
            books= await _db.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
              var book = await _db.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            
            
        }
    }
}
