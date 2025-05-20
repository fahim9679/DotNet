using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="User Name Field required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Field required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
