using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT.CS6460.BuddyUp.WebAPP.Models;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Communicator;

namespace GT.CS6460.BuddyUp.WebAPP.Controllers
{
    public class CourseController : Controller
    {
        private CourseCommunicator _courseCom = new CourseCommunicator();
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

        public ActionResult UnregisteredTeacher()
        {
            ViewBag.User = MvcApplication.userName;
            return View();
        }

        public ActionResult UnregisteredStudent()
        {
            ViewBag.User = MvcApplication.userName;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.User = MvcApplication.userName;
            //CreateCourseModel ccm = new CreateCourseModel();
            //ccm.Users = new List<CourseUser>() { new CourseUser() { emailId = MvcApplication.userEmail, role = Models.Role.Teacher } };
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCourseModel model)
        {
            if (ModelState.IsValid)
            {
                CourseAddRequest car = new CourseAddRequest()
                {
                    CourseCode = model.CourseCode,
                    CourseName = model.CourseName,
                    DesiredSkillSets = model.DesiredSkillSets,
                    GroupSize = model.GroupSize,
                    PreferSimiliarSkillSet = model.PreferSimiliarSkillSet,
                    userList = new List<CourseNewUser>()
                };
                switch(model.GroupType)
                {
                    case "Study Group":
                        car.GroupType = "Study";
                        break;
                    case "Project Group (Open Projects)":
                        car.GroupType = "OpenProject";
                        break;
                    case "Project Group (Closed Projects)":
                        car.GroupType = "ClosedProject";
                        break;
                }

                if (!string.IsNullOrWhiteSpace(model.Teachers))
                {
                    foreach (var user in model.Teachers.Split(','))
                    {
                        car.userList.Add(new CourseNewUser()
                        {
                            emailId = user,
                            roleCode = "Teacher"
                        });
                    }
                }
                if (!string.IsNullOrWhiteSpace(model.TAs))
                {
                    foreach (var user in model.TAs.Split(','))
                    {
                        car.userList.Add(new CourseNewUser()
                        {
                            emailId = user,
                            roleCode = "TA"
                        });
                    }
                }
                bool result = _courseCom.AddCourse(car).Result;
                if (result)
                {
                    MvcApplication.courses.Add(model.CourseCode, model.CourseName);
                    return RedirectToAction("Teacher", "Course");
                }
            }
            ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
            return View(model);
        }

        public ActionResult Teacher()
        {
            return View();
        }
    }
}