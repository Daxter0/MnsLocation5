using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class Material
    {
        public int ID { get; set; }
        public List<RentalCart> Cart { get; set; }

        [ForeignKey("MaterialTypeID")]
        public MaterialType MaterialType { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Statut { get; set; }
    }
}
