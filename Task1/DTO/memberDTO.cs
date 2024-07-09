using System.ComponentModel.DataAnnotations;
using Task1.Models;

namespace Task1.DTO
{
    public class memberDTO
    {
        
        public int memberId { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
