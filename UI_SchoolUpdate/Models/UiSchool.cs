using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI_SchoolUpdate.Models
{
    [Table("uischooldb")]
    public class UiSchool
    {
        [Key]
        public int RollNo { get; set; }
        public int SchoolId { get; set; }
        public int marks { get; set; }
        public string? Student { get; set; }
        public string? Subject { get; set; }

    }
}
