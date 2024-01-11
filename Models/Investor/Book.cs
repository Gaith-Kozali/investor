using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investor.Models.Investor
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
    //    [Required]
      //  string bookFile { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string author { get; set; }
        [Required(ErrorMessage = "Please enter the book price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public double price { get; set; }

        public string image { get; set; }

        [ForeignKey("InvestoreAccounts")]
        public int InvestoreAccountId { get; set; }

        [ForeignKey("Coupon")]
        public int ? CouponId { get; set; }
        public Coupon ? Coupon { get; set; }

    }
}
