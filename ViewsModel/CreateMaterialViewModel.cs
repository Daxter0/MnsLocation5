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
        public List<Material> ListMaterial { get; set; }
        public List<SelectListItem> ListType { get; set; }
        public List<SelectListItem> ListConditions { get; set; }
        public List<SelectListItem> ListStatut { get; set; }
        public List<List<Material>> ListOfListMaterials{ get; set; }
        public List<Rent> ListRents { get; set; }
        public User User { get; set; } = new User();
        public List<User> Users { get; set; } = new List<User>();
        public List<RentalCart> RentalCarts { get; set; } = new List<RentalCart>();
        public RentalCart RentalCart { get; set; } = new RentalCart();
        public MaterialRentalCart MaterialRentalCart { get; set; } = new MaterialRentalCart();
        public List<Material> ChoosenMaterials { get; set; } = new List<Material>();
        public List<RentValidation> RentValidationList { get; set; }
        public Dictionary<RentValidation,User> RentValidationUser { get; set; }
        public int Quantity { get; set; }

        public CreateMaterialViewModel()
        {
            Material = new Material();
            MaterialType = new MaterialType();
            ListType = new List<SelectListItem>();
            ListStatut = new List<SelectListItem>();
            ListOfListMaterials= new List<List<Material>>();
            RentValidationList = new List<RentValidation>();
            RentValidationUser = new Dictionary<RentValidation, User>();
            Quantity = 0;
        }
        public CreateMaterialViewModel(Material material, MaterialType materialType, List<SelectListItem> listType)
        {
            Material = material ?? throw new ArgumentNullException(nameof(material));
            MaterialType = materialType ?? throw new ArgumentNullException(nameof(materialType));
            ListType = listType ?? throw new ArgumentNullException(nameof(listType));
        }

       
    }
}
