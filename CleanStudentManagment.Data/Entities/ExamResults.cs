using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data.Entities
{
    public class ExamResults
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Students Students { get; set; }
        public int QnAsId { get; set; }
        public virtual QnAs QnAs { get; set; }
        public int ExamId { get; set; }
        public virtual Exams Exams { get; set; }
        public int Answer { get; set; }
    }
}
