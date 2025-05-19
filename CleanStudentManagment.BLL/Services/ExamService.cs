using CleanStudentManagment.Data.Entities;
using CleanStudentManagment.Data.UnitOfWork;
using CleanStudentManagment.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public void AddExam(CreateExamVeiwModel examViewModel)
        {
            try
            {
                var model = examViewModel.ConvertToModel(examViewModel);
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
                List<ExamViewModel> examViewModels = new List<ExamViewModel>();
                var examList = _unitOfWork.GenericRepository<Exams>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();
                examViewModels = ListInfo(examList);
                var result = new PagedResult<ExamViewModel>
                {
                    Data = examViewModels,
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

        public IEnumerable<ExamViewModel> GetAllExams()
        {
            try
            {
                List<ExamViewModel> examList = new List<ExamViewModel>();
                var exams = _unitOfWork.GenericRepository<Exams>().GetAll().ToList();
                examList = ListInfo(exams);
                return examList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
    }
}
