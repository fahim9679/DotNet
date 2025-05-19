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
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GroupViewModel AddGroup(GroupViewModel groupVM)
        {
            try
            {
                var model = groupVM.ConvertToGroup(groupVM);
                _unitOfWork.GenericRepository<Groups>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
            return groupVM;
        }

        public PagedResult<GroupViewModel> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<GroupViewModel> groupViewModel = new List<GroupViewModel>();
                var groupList = _unitOfWork.GenericRepository<Groups>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();
                groupViewModel = ListInfo(groupList);
                var result = new PagedResult<GroupViewModel>
                {
                    Data = groupViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Groups>().GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<GroupViewModel> ListInfo(List<Groups> groupList)
        {
            return groupList.Select(x => new GroupViewModel(x)).ToList();
        }

        public IEnumerable<GroupViewModel> GetAllGroups()
        {
            try
            {
                List<GroupViewModel> groupViewModel = new List<GroupViewModel>();
                var groupList = _unitOfWork.GenericRepository<Groups>().GetAll().ToList();
                groupViewModel = ListInfo(groupList);
                return groupViewModel;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public GroupViewModel GetGroup(int id)
        {
            var group=_unitOfWork.GenericRepository<Groups>().GetById(id);
            var vm = new GroupViewModel(group);
            return vm;
        }
    }
}
