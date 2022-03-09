using Survey.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Interfaces.Services
{
    public interface ISurveyService
    {
        public Task<List<Question>> GetQuestions();

        public Task<bool> Addsurvey(List<SurveyReply> surveyReplies);

    }
}
