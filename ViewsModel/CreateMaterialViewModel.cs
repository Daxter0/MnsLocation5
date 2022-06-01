using Microsoft.AspNetCore.Mvc.Rendering;
using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.ViewsModel
{
    public class CreateMaterialViewModel
    {
        public Material Material { get; set; }
        public int MaterialID { get; set; }
        public List<SelectListItem> ListType { get; set; }

       
    }
}
