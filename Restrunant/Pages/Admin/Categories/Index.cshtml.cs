using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restrunant.DataAccess.Data;
using Restrunant.Models;

namespace Restrunant.Pages.Admin.Categoties
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IEnumerable<Category> Categoties { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {
            Categoties = _db.Category;
        }
    }
}
