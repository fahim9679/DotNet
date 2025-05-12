using CleanStudentManagment.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class CreateStudentViewModel
    {
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        //public string? ContactNumber { get; set; }
        //public IFormFile? CVFileName { get; set; }
        //public IFormFile? ProfilePicture { get; set; }
        //public int? GroupId { get; set; }

        public Students ConvertToModel(CreateStudentViewModel vm)
        {
            return new Students
            {
                Name = vm.Name,
                UserName = vm.UserName,
                Password = vm.Password,
                //ContactNumber = vm.ContactNumber,
                //CVFileName = vm.CVFileName,
                //ProfilePicture = vm.ProfilePicture,
                //GroupId=vm.GroupId,
            };
        }
    }
}
