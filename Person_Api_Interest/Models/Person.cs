using System.ComponentModel.DataAnnotations;

namespace Person_Api_Interest.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public string? Phone { get; set; }
        [Range(1, 120, ErrorMessage = "Age Must be between 1 and 120")]
        public int? Age { get; set; }
    }
}
