using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.ViewsModel
{
    public class CreateMaterialCMD
    {

        [ForeignKey("MaterialTypeID")]
        public int MaterialType { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Statut { get; set; }
    }
}
