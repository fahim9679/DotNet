using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewModels.StateViewModels
{
    public class EditStateViewModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
    }
}
