using System.ComponentModel.DataAnnotations;

namespace MotoFix.PL.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "البريد الالكترونى مطلوب")]
        [EmailAddress(ErrorMessage = "من فضلك ادخل بريد الكترونى صحيح")]
        public string Email { get; set; }




        [Required(ErrorMessage = "كلمة السر مطلوبة")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
