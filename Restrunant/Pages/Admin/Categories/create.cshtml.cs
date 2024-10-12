using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restrunant.DataAccess.Data;
using Restrunant.Models;


namespace Restrunant.Pages.Admin.Categories
{
    [BindProperties]
    public class createModel : PageModel
    {
        //connecting to db
        private readonly ApplicationDBContext _db;
        public int count = 0;


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
                TempData["Create"] = "New Record Created Successfully";

                return RedirectToPage("Index");
			}
            else
            {
				return Page();

			}
                
         
           
            

        }
    }
}
