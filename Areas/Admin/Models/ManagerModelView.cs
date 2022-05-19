using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.Admin.Models
{
    public class ManagerModelView
    {
        public List<User> Users { get; set; }
        public List<Material> Materials { get; set; }
        public List<MaterialType> Types { get; set; }

        public ManagerModelView()
        {
            Users = new List<User>();
            Materials = new List<Material>();
            Types = new List<MaterialType>();
        }
    }
}
