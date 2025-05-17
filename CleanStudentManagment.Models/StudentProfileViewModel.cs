using CleanStudentManagment.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class StudentProfileViewModel
    {
        

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public string? ContactNumber { get; set; }
        public string? CVFileName { get; set; }
        public IFormFile CVFileUrl { get; set; }
        public string? ProfilePicture { get; set; }
        public IFormFile ProfilePictureUrl { get; set; }
        public StudentProfileViewModel()
        {
            
        }
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public StudentProfileViewModel(Students student)
        {
            Id = student.Id;
            Name = student.Name;
            UserName = student.UserName;
            ContactNumber = student.ContactNumber;
            CVFileName = student.CVFileName;
            ProfilePicture = student.ProfilePicture;
        }
    }
}
