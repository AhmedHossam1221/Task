using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Task1.Models;

namespace Task1.DTO
{
    public class taskDTO
    {
        
        public int taskId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public string status { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        
        public int memberId { get; set; }
    }
}
