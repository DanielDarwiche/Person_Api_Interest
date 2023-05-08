using System.ComponentModel.DataAnnotations;

namespace Person_Api_Interest.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        [Required(ErrorMessage = "Entering Interest-ID is mandatory in this record")]
        public int InterestId { get; set; }
        [Required(ErrorMessage = "Entering Person-ID is mandatory in this record")]
        public int PersonId { get; set; }
        public int? Linkid { get; set; }

    }
}
