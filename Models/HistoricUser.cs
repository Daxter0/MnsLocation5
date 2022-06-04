using System;
using System.Collections.Generic;

namespace MnsLocation5.Models
{
    public class HistoricUser
    {
        public int Id { get; set; }
        public DateTime DateOfModification { get; set; }
        public string ModificationLocation { get; set; }
        public string ModificationValue { get; set; }
        public User User { get; set; }
    }
}
