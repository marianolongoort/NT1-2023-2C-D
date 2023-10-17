using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NT1_2023_2C_D.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base() { }

        public Rol(string rolName) : base(rolName) { }

        [Display(Name = "Nombre")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override string NormalizedName
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }

    }
}