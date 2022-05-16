using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.Admin.Models
{
    public class AdminAccountManagerViewModel
    {
        public List<User> Users { get; set; }

        public AdminAccountManagerViewModel()
        {
            Users = new List<User>();
        }
    }
}
