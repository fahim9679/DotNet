using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data.Entities
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Exams> Exams { get; set; }

    }
}
