using System.ComponentModel.DataAnnotations;

namespace deneme_bigsister_1.Models
{
    public class UserSignUpVM
    {
        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage ="Lütfen kullanıcı adı girin.")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre girin.")]
        public string Password { get; set; }

        [Display(Name ="Şifre tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler farklı!")]
        public string ConfirmPassword { get; set;}
    }
}
