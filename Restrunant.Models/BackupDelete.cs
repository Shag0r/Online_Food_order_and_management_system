using System.ComponentModel.DataAnnotations;

namespace Restrunant.Models
{
    public class BackupDelete
    {

        public int Id { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Out Of range")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
