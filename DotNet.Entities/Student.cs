﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address PermanentAddress { get; set; }
        public ICollection<StudentSkill> StudentSkills { get; set; } =new List<StudentSkill>();
    }
}
