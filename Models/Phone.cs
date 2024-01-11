using System.ComponentModel.DataAnnotations;

namespace Investor.Models
{
    public class Phone
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
