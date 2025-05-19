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

        public IEnumerable<ResultViewModel> GetStudentResult(int studentId)
        {
            try
            {
                var examResults =_unitOfWork.GenericRepository<ExamResults>().GetAll()
                    .Where(x=>x.StudentId == studentId);
                var studnets = _unitOfWork.GenericRepository<Students>().GetAll();
                var exams = _unitOfWork.GenericRepository<Exams>().GetAll();
                var qnAs = _unitOfWork.GenericRepository<QnAs>().GetAll();
                var requiredData=examResults.Join(studnets,er=>er.StudentId,s=>s.Id,(er,s)=>new {er,s})
                    .Join(exams,es=>es.er.ExamId,e=>e.Id,(es,e)=>new {es,e})
                    .Join(qnAs,ese=>ese.es.er.QnAsId,q=>q.Id,(ese,q)=>new ResultViewModel
                    {
                        StudentId=studentId,
                        ExamName = ese.e.Title,
                        TotalQuestions = examResults.Count(a=>a.StudentId==studentId && a.ExamId==ese.e.Id),
                        CorrectAnser = examResults.Count(a=>a.StudentId==studentId && a.ExamId==ese.e.Id && a.Answer==q.Answer),
                        WrongAnswer = examResults.Count(a=>a.StudentId==studentId && a.ExamId==ese.e.Id && a.Answer != q.Answer),
                    });
                return requiredData;
            }
            catch (Exception)
            {

                throw;
            }
            return Enumerable.Empty<ResultViewModel>();
        }

        public bool SetExamResult(AttendExamViewModel viewModel)
        {
            try
            {
                foreach (var item in viewModel.QnAsList)
                {
                    ExamResults results = new ExamResults
                    {
                        StudentId = viewModel.StudentId,
                        ExamId = item.ExamId,
                        QnAsId = item.Id,
                        Answer = item.SelectedAnswer,
                    };
                    _unitOfWork.GenericRepository<ExamResults>().Add(results);
                    _unitOfWork.Save();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool SetGroupIdToStudent(GroupStudentViewModel viewModel)
        {
            try
            {
                foreach (var student in viewModel.StudentList)
                {
                    var studentObj = _unitOfWork.GenericRepository<Students>().GetById(student.Id);
                    if (student.IsChecked == true)
                    {
                        studentObj.GroupId = viewModel.GroupId;
                        _unitOfWork.GenericRepository<Students>().Update(studentObj);
                    }
                    else
                    {
                        studentObj.GroupId = null;
                    }

                }
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        IEnumerable<StudentsViewModel> IStudentService.GetAll()
        {
            try
            {
                var Students = _unitOfWork.GenericRepository<Students>().GetAll().ToList();
                List<StudentsViewModel> StudentViewModelList = new List<StudentsViewModel>();
                StudentViewModelList = ListInfo(Students);
                return StudentViewModelList;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private List<StudentsViewModel> ListInfo(List<Students> StudentList)
        {
            return StudentList.Select(x => new StudentsViewModel(x)).ToList();
        }

        private List<StudentViewModel> ConvertToStudentVM(List<Students> StudentList)
        {
            return StudentList.Select(x => new StudentViewModel(x)).ToList();
        }

        public PagedResult<StudentViewModel> GetAllStudents(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<StudentViewModel> StudentViewModels = new List<StudentViewModel>();
                var studentsList = _unitOfWork.GenericRepository<Students>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();
                StudentViewModels = ConvertToStudentVM(studentsList);
                var result = new PagedResult<StudentViewModel>
                {
                    Data = StudentViewModels,
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

        public StudentProfileViewModel GetStudentById(int id)
        {
            var student = _unitOfWork.GenericRepository<Students>().GetById(id);
            var studentProfile = new StudentProfileViewModel(student);
            return studentProfile;

        }

        public void UpdateProfile(StudentProfileViewModel vm)
        {
            try
            {
                var student = _unitOfWork.GenericRepository<Students>().GetById(vm.Id);
                if (student != null)
                {
                    student.Name = vm.Name;
                    student.UserName = vm.UserName;
                    student.ContactNumber = vm.ContactNumber;
                    if (vm.CVFileUrl != null)
                    {
                        student.CVFileName = vm.CVFileName;
                    }
                    else
                    {
                        student.CVFileName = vm.CVFileName;
                    }
                    if (vm.ProfilePictureUrl != null)
                    {
                        student.ProfilePicture = vm.ProfilePicture;
                    }
                    else
                    {
                        student.ProfilePicture = vm.ProfilePicture;
                    }
                    _unitOfWork.GenericRepository<Students>().Update(student);
                    _unitOfWork.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
