using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.ViewsModel
{
    public class RentalCartViewModel
    {
        public int Id { get; set; }
        public RentalCart Cart { get; set; }
        public int RefUserId { get; set; }
        public ICollection<Material> ChoosenMaterial { get; set; }

        public RentalCartViewModel()
        {
            RefUserId = 0;
            ChoosenMaterial = new List<Material>();
        }
    }
}
