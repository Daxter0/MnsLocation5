using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class RentValidation
    {
        [Key]
        [ForeignKey("Rent")]
        public int RentId { get; set; }
        public DateTime ValidationDate { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User Admin { get; set; }

    }
}
