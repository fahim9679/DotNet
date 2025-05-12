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
        Task<int> AddStudentAsync(CreateStudentViewModel vm);
        IEnumerable<StudentViewModel> GetAllStudents();
        bool SetGroupIdToSutdent(GroupStudentViewModel viewModel);
    }
}
