using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required] // add custom validation message ex: [Required(ErrorMessage ="Get it right!")]

        public string Name { get; set; }
        [DisplayName("Display Order")] //set custom display name
        [Range(1,100,ErrorMessage = "Display order must between 1 and 100.")]//set custom input range and validation message
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
