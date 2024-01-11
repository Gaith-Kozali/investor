using Investor.Models.Investor;
using System.ComponentModel.DataAnnotations;

namespace Investor.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nationalNumber { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string father { get; set; }
        [Required]
        public string mother { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string birthDate { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public string role { get; set; }
        InvestoreAccount investoreAccount { get; set; }


    }
}
