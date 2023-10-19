using System.ComponentModel.DataAnnotations;

namespace deneme_bigsister_1.Models
{
    public class UserSignInVM
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string password { get; set; }

    }
}
