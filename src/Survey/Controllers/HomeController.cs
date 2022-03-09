using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Core.Entities;
using Survey.Core.Interfaces.Services;
using Survey.Models;
using Survey.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISurveyService _surveyService;
        private readonly IMapper _mapper;

        const string question = "question";

        public HomeController(ILogger<HomeController> logger
            , ISurveyService surveyService
            , IMapper mapper)
        {
            _logger = logger;
            _surveyService = surveyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _surveyService.GetQuestions();

            var result = _mapper.Map<List<QuestionViewModel>>(questions);

            return View(result);
        }

        public async Task<IActionResult> SaveSurvey(Dictionary<string, string> surveyModel)
        {
            List<SurveyViewModel> surveyViewModels = CustingSurveyForm(surveyModel);

            var surveyReplies = _mapper.Map<List<SurveyReply>>(surveyViewModels);

            if (await _surveyService.Addsurvey(surveyReplies))

               return RedirectToAction("Thankyou");
            else
                return RedirectToAction("Error");

        }
        public ActionResult Thankyou()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Home/ChangeLanguage")]
        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(SupportedLanguage.en, culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new CultureInfo(SupportedLanguage.en).DateTimeFormat;
            return Redirect(Request.Headers["Referer"].ToString());
        }

        #region Helper Methods.
        private List<SurveyViewModel> CustingSurveyForm(Dictionary<string, string> surveyModel)
        {
            List<SurveyViewModel> surveyViewModels = new List<SurveyViewModel>();
            if (surveyModel != null && surveyModel.Count > 0)
            {
                int questionId;
                int answerId;
                foreach (var item in surveyModel)
                {
                    if (item.Key.Contains(question))
                    {
                        int.TryParse(item.Key.Replace(question, ""), out questionId);
                        int.TryParse(item.Value, out answerId);

                        surveyViewModels.Add(new SurveyViewModel { QuestionId = questionId, AnswerId = answerId });
                    }
                }

            }
            return surveyViewModels;

        }
        #endregion
    }

}
