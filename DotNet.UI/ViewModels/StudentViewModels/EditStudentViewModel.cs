using DotNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewModels.StudentViewModels
{
    public class EditStudentViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public Address PhysicalAddress { get; set; }
        public List<CheckBoxTable> SkillList { get; set; } = new List<CheckBoxTable>();
    }
}
