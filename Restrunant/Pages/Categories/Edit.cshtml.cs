using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restrunant.Data;
using Restrunant.Model;

namespace Restrunant.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        //connecting to db
        private readonly ApplicationDBContext _db;
        int count = 0;

        public Category Category { get; set; }

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
            
        }
        public void OnGet( int id)
        {
            Category = _db.Category.FirstOrDefault(i=>i.Id==id);
            


        }


        public async Task<IActionResult> OnPost()
        {
            
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
            count=count+1;
            if (count > 0)

            {
                TempData["success"] = "Record Updated Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
                
        
          // ModelState.Clear();
           // return Page();
            

        }
    }
}
