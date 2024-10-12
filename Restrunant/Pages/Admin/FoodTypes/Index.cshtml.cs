using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restrunant.DataAccess.Data;
using Restrunant.Models;

namespace Restrunant.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IEnumerable<FoodType> food { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {
            food = _db.FoodType;
        }
    }
}
