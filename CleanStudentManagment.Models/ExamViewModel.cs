using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }
        public ExamViewModel(Exams exams )
        {
            Id = exams.Id;
            Title = exams.Title;
            Description = exams.Description;
            StartDate = exams.StartDate;
            Time = exams.Time;
            GroupId = exams.GroupId;
        }
    }
}
