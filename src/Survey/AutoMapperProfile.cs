using AutoMapper;
using Survey.Core.Entities;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<SurveyReply, SurveyViewModel>().ReverseMap();
            
        }   

    }
}
