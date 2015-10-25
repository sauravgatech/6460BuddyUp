using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT.CS6460.BuddyUp.WebAPP.Models;

namespace GT.CS6460.BuddyUp.WebAPP.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult JoinACourse()
        {
            JoinACourseQuestionnaireModel jac = new JoinACourseQuestionnaireModel();
            List<QuestionAndAnswerModel> qas = new List<QuestionAndAnswerModel>();
            for (int i = 0; i < 5; i++ )
            {
                QuestionAndAnswerModel qam = new QuestionAndAnswerModel()
                {
                    Question = "The Quick Brown fox jumped over the lazy dog?",
                    QuestionType = QuestionType.MultipleChoice,
                    Choice1 = "The",
                    Choice2 = "Quick",
                    Choice3 = "Brown",
                    Choice4 = "Fox"
                };
                qas.Add(qam);
            }
            for (int i = 0; i < 4; i++ )
            {
                QuestionAndAnswerModel qam = new QuestionAndAnswerModel()
                {
                    QuestionType = QuestionType.FillUpTheBlank,
                    Question = "Some Text Answer required question"
                };
                qas.Add(qam);
            }
                jac.questionAnswerSet = qas;
            return View(jac);
        }
    }
}