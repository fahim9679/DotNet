using DotNet.UI.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewModels.SkillViewModels
{
    public class CreateSkillViewModel
    {
        [Uppercase]
        public string Title { get; set; }
    }
}
