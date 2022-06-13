using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class RentValidation
    {
        [Key]
        public int RentId { get; set; }
        [ForeignKey("RentId")]
        public Rent Rent { get; set; }
        public DateTime ValidationDate { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User Admin { get; set; }

    }
}
