using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investor.Models.Investor
{
    public class InvestoreAccount
    {
        [Key]
        public int id { set; get; }
        [Required]
        public string userName { set; get; }
        [Required]
        public string password { set; get; }
        [Required]
        public string companyName { set; get; }

        [ForeignKey("person")]
        public int PersonId { set; get; }
        public  Person person { set; get; }
        public ICollection<Profit> profit { set; get; }
        public ICollection<Book> book { set; get; }
    }
}
