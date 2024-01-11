using System.ComponentModel.DataAnnotations;

namespace Investor.Models
{
    public class Email
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string email { get; set; }

    }
}
