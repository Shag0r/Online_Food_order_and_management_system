using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restrunant.Data;
using Restrunant.Model;

namespace Restrunant.Pages.Categories
{
    [BindProperties]
    public class createModel : PageModel
    {
        //connecting to db
        private readonly ApplicationDBContext _db;


        public Category Category { get; set; }

        public createModel(ApplicationDBContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {
            
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
           ModelState.Clear();
            return Page();
            

        }
    }
}
