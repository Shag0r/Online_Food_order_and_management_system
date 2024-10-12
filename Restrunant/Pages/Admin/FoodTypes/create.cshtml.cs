using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restrunant.DataAccess.Data;
using Restrunant.Models;


namespace Restrunant.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class createModel : PageModel
    {
        //connecting to db
        private readonly ApplicationDBContext _db;
        public int count = 0;


        public FoodType food { get; set; }

        public createModel(ApplicationDBContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {
            
        }


        public async Task<IActionResult> OnPost()
        {
            
                await _db.FoodType.AddAsync(food);
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
