using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        ApplicationDBContext dbContext;
        public CreateModel(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        [BindProperty]
        public Book book { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await dbContext.Books.AddAsync(book);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
