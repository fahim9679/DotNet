using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class StudentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentsViewModel(Students students )
        {
            Id = students.Id;
            Name = students.Name;
        }

    }
    public class CheckBoxTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
