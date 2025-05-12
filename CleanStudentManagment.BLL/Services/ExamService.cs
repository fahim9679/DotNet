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
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddExam(CreateExamsViewModel viewModel)
        {
            try
            {
                var model = viewModel.ConvertToModel(viewModel);
                _unitOfWork.GenericRepository<Exams>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public PagedResult<ExamViewModel> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<ExamViewModel> examViewModel = new List<ExamViewModel>();
                var examList = _unitOfWork.GenericRepository<Exams>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();
                examViewModel = ListInfo(examList);
                var result = new PagedResult<ExamViewModel>
                {
                    Data = examViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Exams>().GetAll().Count(),
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
        private List<ExamViewModel> ListInfo(List<Exams> examList)
        {
            return examList.Select(x => new ExamViewModel(x)).ToList();
        }
    }
}
