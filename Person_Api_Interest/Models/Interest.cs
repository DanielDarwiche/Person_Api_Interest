using System.ComponentModel.DataAnnotations;

namespace Person_Api_Interest.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required(ErrorMessage = "Dont forget to write interest")]
        public string InterestName { get; set; }
        [Required(ErrorMessage = "Description.... Dont forget")]
        public string InterestDescription { get; set; }
    }
}
