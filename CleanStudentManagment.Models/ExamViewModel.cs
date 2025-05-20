using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanStudentManagment.Models
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public string GroupName { get; set; }
        public ExamViewModel()
        {
            
        }

        public ExamViewModel(Exams exams)
        {
            Id = exams.Id;
            Title = exams.Title;    
            Description = exams.Description;
            StartDate = exams.StartDate;
            Time = exams.Time;
            GroupName = exams.Groups.Name;

        }
    }
}
