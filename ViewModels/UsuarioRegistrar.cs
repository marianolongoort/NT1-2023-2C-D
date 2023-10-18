using System.ComponentModel.DataAnnotations;

namespace NT1_2023_2C_D.ViewModels
{
    public class UsuarioRegistrar
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(50,MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="No coincide con la contraseña")]
        public string ConfirmPassword { get; set; }


    }
}
