using Survey.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
