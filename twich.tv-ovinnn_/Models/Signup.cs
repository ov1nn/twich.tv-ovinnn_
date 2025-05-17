using System.ComponentModel.DataAnnotations;

namespace twich.tv_ovinnn_.Models
{
    public class Signup
    {
        [Required(ErrorMessage = "Логин не введен")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пароль не введен")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }
    }
}
