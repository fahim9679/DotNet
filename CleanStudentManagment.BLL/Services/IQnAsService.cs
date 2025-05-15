using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public interface IQnAsService
    {
        void AddQnAs(CreateQnAsViewModel vm);
        PagedResult<QnAsViewModel> GetAllQnAs(int pageNumber, int pageSize);
    }
}
