using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public interface IExamService
    {
        PagedResult<ExamViewModel> GetAllExams(int pageNumber, int pageSize);
        void AddExam(CreateExamVeiwModel examViewModel);
        IEnumerable<ExamViewModel> GetAllExams();
    }
}
