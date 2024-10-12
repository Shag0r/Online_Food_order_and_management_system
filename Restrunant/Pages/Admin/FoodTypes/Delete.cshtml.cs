using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restrunant.DataAccess.Data;
using Restrunant.Models;

namespace Restrunant.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Data.ApplicationDBContext _db;
        public int count = 0;

        public FoodType food { get; set; }
        public BackupFoodType BackupFoodType { get; set; }
       
        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;

        }
        public void OnGet(int id)
        {
            food = _db.FoodType.Find(id);

        }

        public async Task<IActionResult> OnPost(int id)
        {
            food = _db.FoodType.Find(id);
            BackupFoodType = new BackupFoodType
            {
                Name = food.Name
               
            };
            await  _db.BackupFoodType.AddAsync(BackupFoodType);
            _db.FoodType.Remove(food);
            await _db.SaveChangesAsync();
            count = count + 1;
            if (count > 0)
            {
                TempData["Delete"] = "Record Deleted Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();

            }





        }

    }
}
