using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public interface IStudentService
    {
        PagedResult<StudentViewModel> GetAllStudents(int pageNumber, int pageSize);
        Task<int> AddStudentAsync(CreateStudentViewModel vm);
        IEnumerable<StudentsViewModel> GetAll();
        IEnumerable<ResultViewModel> GetStudentResult(int studentId);
        bool SetExamResult(AttendExamViewModel viewModel);
        bool SetGroupIdToStudent(GroupStudentViewModel viewModel);
        StudentProfileViewModel GetStudentById(int id);
        void UpdateProfile(StudentProfileViewModel vm);
    }
}
