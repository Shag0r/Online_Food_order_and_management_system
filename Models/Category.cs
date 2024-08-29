using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Out Of range")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
