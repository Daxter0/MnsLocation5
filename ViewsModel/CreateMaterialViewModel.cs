using Microsoft.AspNetCore.Mvc.Rendering;
using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.ViewsModel
{
    public class CreateMaterialViewModel
    {
        public Material Material { get; set; }
        public IList<SelectListItem> ListType { get; set; }

        public CreateMaterialViewModel()
        {
            Material = new Material();
            ListType = new List<SelectListItem>();
        }
    }
}
