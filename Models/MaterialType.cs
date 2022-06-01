using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MnsLocation5.Models
{
    public class MaterialType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Material> Materials { get; set; }
    }
}
