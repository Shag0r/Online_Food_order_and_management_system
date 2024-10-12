using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restrunant.DataAccess.Data;
using Restrunant.Models;

namespace Restrunant.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Data.ApplicationDBContext _db;
        public int count = 0;

        public Category Category { get; set; }
        public BackupDelete BackupDelete { get; set; }
       
        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;

        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);

        }

        public async Task<IActionResult> OnPost(int id)
        {
            Category = _db.Category.Find(id);
            BackupDelete = new BackupDelete
            {
                Name = Category.Name,
                DisplayOrder = Category.DisplayOrder,
            };
            await  _db.BackupDeletes.AddAsync(BackupDelete);
            _db.Category.Remove(Category);
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
