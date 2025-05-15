using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data.Entities
{
    public class Exams
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual ICollection<ExamResults> ExamResults { get; set; }
        public virtual ICollection<QnAs> QnAss  { get; set; }
    }
}
