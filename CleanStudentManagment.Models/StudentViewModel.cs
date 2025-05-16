using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string UserName { get; set; }
        public string? Contact { get; set; }

        public StudentViewModel()
        {
            
        }
        public StudentViewModel(Students students)
        {
            StudentId = students.Id;
            StudentName = students.Name;
            UserName = students.UserName;
            Contact = students.ContactNumber;
        }
    }
}
