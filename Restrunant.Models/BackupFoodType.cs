using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restrunant.Models
{
    public class BackupFoodType
    {
        
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
    }
}
