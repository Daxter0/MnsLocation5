using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.Admin.Models
{
    public class AdminManagerModelView
    {
        public List<User> Users { get; set; }
        public List<Material> Materials { get; set; }

        public AdminManagerModelView()
        {
            Users = new List<User>();
            Materials = new List<Material>();
        }
    }
}
