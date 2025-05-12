using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public interface IGroupService
    {
        PagedResult<GroupViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<GroupViewModel> GetAllGroups();
        GroupViewModel GetGroup(int id);
        GroupViewModel AddGroup(GroupViewModel group);

    }
}
