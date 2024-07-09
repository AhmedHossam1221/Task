using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class teamMember
    {
        [Key]
        public int memberId { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public virtual List<Tasks>? Tasks { get; set; }
    }
}
