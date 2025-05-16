﻿using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GroupViewModel()
        {
            
        }
        public Groups ConvertToGroup(GroupViewModel groupViewModel)
        {
            return new Groups { Id = groupViewModel.Id, Name = groupViewModel.Name, Description = groupViewModel.Description };
        }
        public GroupViewModel(Groups groups)
        {
            Id= groups.Id;
            Name = groups.Name;
            Description = groups.Description;
        }
    }
}
