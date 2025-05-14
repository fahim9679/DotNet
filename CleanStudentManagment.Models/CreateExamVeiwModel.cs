using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class CreateExamVeiwModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }

        public Exams ConvertToModel(CreateExamVeiwModel examViewModel)
        {
            return new Exams
            {
                Title = examViewModel.Title,
                Description = examViewModel.Description,
                StartDate = examViewModel.StartDate,
                Time = examViewModel.Time,
                GroupId = examViewModel.GroupId
            };
        }
    }
}
