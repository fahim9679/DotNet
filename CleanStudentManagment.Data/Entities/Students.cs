using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? ContactNumber { get; set; }
        public string? CVFileName { get; set; }
        public string? ProfilePicture { get; set; }
        public int? GroupId { get; set; }
    }
}
