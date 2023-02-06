using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC2022.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o Email")]
        [Display(Name ="Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        //Exibirá os carecteres de senha ao inves do texto aberto
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [StringLength(10, ErrorMessage ="Senha com no mínimo 6 caracteres,máximo 10", MinimumLength =6)]
        
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

    }
}
