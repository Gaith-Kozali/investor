using System.ComponentModel.DataAnnotations;

namespace Investor.Models.Investor
{
    public class Coupon
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        
        [Required(ErrorMessage = "Please enter the value of discount")]
        [Range(0.01,1, ErrorMessage = "discount range between {1} and {2}")]
        public double discount { get; set; }
        [Required]
        public string timePeriodc { get; set; }

       public ICollection<Book> book { get; set; }
    }
}
