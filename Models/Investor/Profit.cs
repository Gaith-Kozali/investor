using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investor.Models.Investor
{
    public class Profit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double profit { get; set; }
        [Required]
        public DateTime date { get; set; }

        [ForeignKey("investoreAccount")]
        public int investoreAccountId { get; set; }
        public InvestoreAccount investoreAccount { get; set; }
    }
}
