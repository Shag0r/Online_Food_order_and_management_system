using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restrunant.DataAccess.Data;
using Restrunant.Models;

namespace Restrunant.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public int count = 0;
        
        public FoodType food { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            _db = db;

        }
        public void OnGet(int id )
        {
            food = _db.FoodType.Find(id);

        }
        public async Task<IActionResult> OnPost()
        {

            _db.FoodType.Update(food);
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
