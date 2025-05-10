using System.ComponentModel.DataAnnotations;

namespace DotNet.UI.ViewModels.UserInfoViewModels
{
    public class UserInfoViewModel
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
