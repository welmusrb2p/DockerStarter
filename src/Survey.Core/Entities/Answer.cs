using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Core.Entities
{
   public class Answer
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public bool IsActive { get; set; }
        public int QuesionId { get; set; }


    }
}
