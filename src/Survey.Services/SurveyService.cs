using Survey.Core.Entities;
using Survey.Core.Interfaces.Infastructure;
using Survey.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IBaseRepository<Question> _questionRepo;
        private readonly IBaseRepository<SurveyReply> _surveyReplyRepo;
        private readonly IUnitOfWork _unitOfWork;
        public SurveyService(IBaseRepository<Question> questionRepo
            , IBaseRepository<SurveyReply> surveyReplyRepo
            , IUnitOfWork unitOfWork)
        {
            _questionRepo = questionRepo;
            _surveyReplyRepo = surveyReplyRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Question>> GetQuestions()
        {
            return (await _questionRepo.GetAllAsync(new string[] { "Answers" })).ToList();
        }

        public async Task<bool> Addsurvey(List<SurveyReply> surveyReplies)
        {
            await _surveyReplyRepo.AddRange(surveyReplies);
            return (await _unitOfWork.CommitAsync() > 0);
        }


    }
}
