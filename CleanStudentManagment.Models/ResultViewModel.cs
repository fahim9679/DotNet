using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class ResultViewModel
    {
        public int StudentId { get; set; }
        public string ExamName { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnser { get; set; }
        public int WrongAnswer { get; set; }

    }
}
