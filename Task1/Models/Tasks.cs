using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task1.Models
{
    public class Tasks
    {
        [Key]
        public int taskId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public string status { get; set; }
        
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        [ForeignKey("teamMember")]
        public int memberId { get; set; }
        public virtual teamMember teamMember { get; set; }


    }
}
