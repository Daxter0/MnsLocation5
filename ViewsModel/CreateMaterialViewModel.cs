using Microsoft.AspNetCore.Mvc.Rendering;
using MnsLocation5.Models;
using System;
using System.Collections.Generic;

namespace MnsLocation5.ViewsModel
{
    public class CreateMaterialViewModel
    {
        public Material Material { get; set; }
        public int MaterialTypeID { get; set; }
        public MaterialType MaterialType { get; set; }
        public ICollection<Material> ListMaterial { get; set; }
        public List<SelectListItem> ListType { get; set; }
        public List<SelectListItem> ListConditions { get; set; }
        public List<SelectListItem> ListStatut { get; set; }


        public CreateMaterialViewModel()
        {
            Material = new Material();
            MaterialType = new MaterialType();
            ListType = new List<SelectListItem>();
            ListStatut = new List<SelectListItem>();
        }
        public CreateMaterialViewModel(Material material, MaterialType materialType, List<SelectListItem> listType)
        {
            Material = material ?? throw new ArgumentNullException(nameof(material));
            MaterialType = materialType ?? throw new ArgumentNullException(nameof(materialType));
            ListType = listType ?? throw new ArgumentNullException(nameof(listType));
        }
    }
}
