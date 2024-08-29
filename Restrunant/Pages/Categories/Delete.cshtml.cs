using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restrunant.Data;
using Restrunant.Model;

namespace Restrunant.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        //connecting to db
        private readonly ApplicationDBContext _db;
        int count = 0;

        public Category Category { get; set; }

        public BackUpCatagory BackUp { get; set; }

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
            
        }
        public void OnGet( int id)
        {
            Category = _db.Category.FirstOrDefault(i=>i.Id==id);
            


        }


        public async Task<IActionResult> OnPost()
        {
            BackUp = new BackUpCatagory
            {
                //Id = Category.Id,
                Name = Category.Name,
                DisplayOrder = Category.DisplayOrder
            };

            await _db.BackCatagory.AddAsync(BackUp);// wanted to back and store the data into another table
             _db.Category.Remove(Category);
            await _db.SaveChangesAsync();
            count=count+1;
            if (count > 0)

            {
                TempData["danger"] = "Record Deleted Successfully";
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
