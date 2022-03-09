using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Core.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Answer> Answers { get; set; }


    }
}
