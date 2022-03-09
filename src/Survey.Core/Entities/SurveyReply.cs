using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Core.Entities
{
    public class SurveyReply
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

        public DateTime CreationDate { get; set; }


    }
}
