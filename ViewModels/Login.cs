using NT1_2023_2C_D.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NT1_2023_2C_D.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = ErrorMessages.ReqMsg)]
        [EmailAddress(ErrorMessage = "No valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.ReqMsg)]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        public bool Recordarme { get; set; } = false;
    }
}
