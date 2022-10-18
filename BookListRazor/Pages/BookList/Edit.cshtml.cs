using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        ApplicationDBContext _db;

        public EditModel(ApplicationDBContext dBContext)
        {
            _db = dBContext;
        }

        [BindProperty]
        public Book book { get; set; }
        public async Task OnGet(int id)
        {
            try
            {
                book = await _db.Books.FindAsync(id);
            }
            catch(Exception ex)
            {
                Response.Redirect("Index");
            }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = await _db.Books.FindAsync(book.BookId);
                    obj.Name = book.Name;
                    obj.Author = book.Author;
                    obj.ISBN = book.ISBN;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
                catch(Exception ex)
                {
                    return RedirectToPage("Index");
                }
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
