using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restrunant.Data;
using Restrunant.Model;

namespace Restrunant.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public int count = 0;
        
        public Category Category { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            _db = db;

        }
        public void OnGet(int id )
        {
            Category = _db.Category.Find(id);

        }
        public async Task<IActionResult> OnPost()
        {

            _db.Category.Update(Category);
            await _db.SaveChangesAsync();
            count = count + 1;
            if (count > 0)
            {
                TempData["Edit"] = "Record Updated Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();

            }





        }
    }
}
