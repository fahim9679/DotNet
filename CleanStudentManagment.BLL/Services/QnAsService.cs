using CleanStudentManagment.Data.Entities;
using CleanStudentManagment.Data.UnitOfWork;
using CleanStudentManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.BLL.Services
{
    public class QnAsService : IQnAsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QnAsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddQnAs(CreateQnAsViewModel vm)
        {
            try
            {
                var model = vm.ConvertToModel(vm);
                _unitOfWork.GenericRepository<QnAs>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public PagedResult<QnAsViewModel> GetAllQnAs(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<QnAsViewModel> qnAsViewModels = new List<QnAsViewModel>();
                var qnAsList = _unitOfWork.GenericRepository<QnAs>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();
                qnAsViewModels = ListInfo(qnAsList);
                var result = new PagedResult<QnAsViewModel>
                {
                    Data = qnAsViewModels,
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

        private List<QnAsViewModel> ListInfo(List<QnAs> qnAsList)
        {
            return qnAsList.Select(x => new QnAsViewModel(x)).ToList();
        }
    }
}
