using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class Material
    {
        public int MaterialID { get; set; }
        public int TypeRefId { get; set; }

        [ForeignKey("TypeRefId")]
        public MaterialType Type { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Statut { get; set; }
        public ICollection<RentalCart> RentalCarts { get; set; }
    }
}
