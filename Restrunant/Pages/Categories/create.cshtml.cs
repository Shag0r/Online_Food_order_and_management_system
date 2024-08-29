using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Restrunant.Data;


namespace Restrunant.Pages.Categories
{
    [BindProperties]
    public class createModel : PageModel
    {
        //connecting to db
        private readonly ApplicationDBContext _db;
        int count = 0;


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
            
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
            count=count+1;
            if (count > 0)
            {

                TempData["success"] = "Record Created Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                ModelState.Clear();
                return Page();

            }
            
          
            

        }
    }
}
