using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.Admin.Models
{
    public class AdminMaterielManagerViewModel
    {
        public List<Material> Materials { get; set; }

        public AdminMaterielManagerViewModel()
        {
            Materials = new List<Material>();
        }
    }
}
