using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewModels.CityViewModels
{
    public class EditCityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        [Display(Name = "State Name")]
        public int StateId { get; set; }
    }
}
