using CleanStudentManagment.Data.Entities;
using CleanStudentManagment.Data.UnitOfWork;
using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddStudentAsync(CreateStudentViewModel vm)
        {
            try
            {
                Students Obj = vm.ConvertToModel(vm);
                await _unitOfWork.GenericRepository<Students>().AddAsync(Obj);
                _unitOfWork.Save();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        IEnumerable<StudentViewModel> IStudentService.GetAllStudents()
        {
            try
            {
                var Students = _unitOfWork.GenericRepository<Students>().GetAll().ToList();
                List<StudentViewModel> StudentViewModelList = new List<StudentViewModel>();
                StudentViewModelList = ListInfo(Students);
                return StudentViewModelList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private List<StudentViewModel> ListInfo(List<Students> StudentList)
        {
            return StudentList.Select(x=>new StudentViewModel(x)).ToList();
        }
    }
}
