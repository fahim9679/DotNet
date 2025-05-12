using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class CreateExamsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }

        public Exams ConvertToModel(CreateExamsViewModel model)
        {
            return new Exams
            {
                Title = model.Title,
                Description = model.Description,
                StartDate = model.StartDate,
                Time = model.Time,
                GroupId = model.GroupId,
            };
        }
    }
}
