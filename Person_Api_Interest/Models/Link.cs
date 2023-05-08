using System.ComponentModel.DataAnnotations;

namespace Person_Api_Interest.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        [Required(ErrorMessage = "You must enter a link! ")]
        public string LinkURL { get; set; }
    }
}
