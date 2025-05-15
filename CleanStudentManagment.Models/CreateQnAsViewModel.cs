﻿using CleanStudentManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Models
{
    public class CreateQnAsViewModel
    {
        public string QuestionTitle { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public QnAs ConvertToModel(CreateQnAsViewModel vm)
        {
            return new QnAs
            {
                QuestionTitle = vm.QuestionTitle,
                Answer = vm.Answer,
                ExamId = vm.ExamId,
                Option1 = vm.Option1,
                Option2 = vm.Option2,
                Option3 = vm.Option3,
                Option4 = vm.Option4
            };
        }
    }
}
