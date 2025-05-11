using CleanStudentManagment.Data.Entities;
using CleanStudentManagment.Data.UnitOfWork;
using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddTeacher(UserViewModel vm)
        {
            try
            {
                Users model = new Users
                {
                    Name = vm.Name,
                    UserName = vm.UserName,
                    Password = vm.Password,
                    Role = (int)EnumRoles.Teacher,
                };
                _unitOfWork.GenericRepository<Users>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public PagedResult<TeacherViewModel> GetAllTeacher(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public LoginViewModel Login(LoginViewModel loginViewModel)
        {

            var user = _unitOfWork.GenericRepository<Users>().GetAll()
                .FirstOrDefault(x => x.UserName == loginViewModel.UserName.Trim()
                                && x.Password == loginViewModel.Password
                                && x.Role == loginViewModel.Role);
            if (user != null)
            {
                loginViewModel.Id = user.Id;
                return loginViewModel;
            }
            return null;
        }

    }
}
