using System;
using System.Text;
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
        private QuestionnaireCommunicator _questionnaireCom = new QuestionnaireCommunicator();
        private CourseUserCommunicator _courseUserCom = new  CourseUserCommunicator();
        // GET: Course
        public ActionResult JoinACourse(string courseCode)
        {
            CourseGetResponse cgr = _courseCom.GetCourse(courseCode).Result;
            DisplayCourseModel dcm = new DisplayCourseModel();
            if (cgr != null)
            {
                dcm.CourseCode = cgr.CourseCode;
                dcm.CourseDescription = cgr.CourseDescription;
                dcm.CourseName = cgr.CourseName;
                dcm.DesiredSkillSets = cgr.DesiredSkillSets;
                dcm.GroupSize = (int)cgr.GroupSize;
                dcm.GroupType = cgr.GroupType;
                dcm.PreferSimiliarSkillSet = (bool)cgr.PreferSimiliarSkillSet;
                dcm.Users = new List<Models.DisplayCourseUser>();
                dcm.Questions = new List<Models.DsiplayQuestion>();
            }
            foreach (var user in cgr.UserList)
            {
                dcm.Users.Add(new DisplayCourseUser()
                {
                    emailId = user.EmailID,
                    name = user.Name,
                    role = user.RoleCode
                });
            }

            QuestionnaireGetResponse qgr = _questionnaireCom.GetQuestionnaire(cgr.QuestionnaireCode).Result;

            if (qgr != null)
            {
                foreach (var q in qgr.Questions)
                {
                    dcm.Questions.Add(new Models.DsiplayQuestion()
                    {
                        QuestionText = q.questionText,
                        QuestionType = q.questionType,
                        AnswerChoices = q.answerChoices
                    });
                }
            }
            return View(dcm);
        }

        public ActionResult UnregisteredTeacher()
        {
            ViewBag.User = MvcApplication.userName;
            return View();
        }

        public ActionResult Student()
        {
            StudentDashboardModel sdm = new StudentDashboardModel();
            sdm.AllCourseDropDown = new List<string>();
            sdm.selectedCourse = null;
            sdm.selectedRegisteredCourse = null;
            List<CourseGetResponse> cgrs = _courseCom.GetAllCourses().Result.ToList();
            sdm.RegisteredCourseDropDown = new List<string>();
            if (cgrs != null)
            {
                foreach(var cgr in cgrs)
                {
                    if(cgr.CourseCode != "Default" && !MvcApplication.courses.Keys.Contains(cgr.CourseCode))
                        sdm.AllCourseDropDown.Add(cgr.CourseCode + " :: " + cgr.CourseName);
                }
            }
            if(MvcApplication.courses != null && MvcApplication.courses.Count > 0)
            {
                foreach(var crs in MvcApplication.courses)
                {
                    sdm.RegisteredCourseDropDown.Add(crs.Key + " :: " + crs.Value);
                }
            }
            return View(sdm);
        }


        [HttpPost]
        public async Task<ActionResult> Student(StudentDashboardModel model)
        {
            if(ModelState.IsValid)
            {
                string[] stringSeparators = new string[] {" :: "};
                if(!string.IsNullOrWhiteSpace(model.selectedRegisteredCourse))
                {
                    string courseCode = model.selectedRegisteredCourse.Split(stringSeparators, StringSplitOptions.None).FirstOrDefault();
                    return RedirectToAction("GroupSummary", "Group", routeValues: new { courseCode = courseCode });
                }
                if(!string.IsNullOrWhiteSpace(model.selectedCourse))
                {
                    string courseCode = model.selectedCourse.Split(stringSeparators, StringSplitOptions.None).FirstOrDefault();
                    return RedirectToAction("JoinACourse", "Course", routeValues: new { courseCode = courseCode });
                }
            }
            ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> JoinACourse(DisplayCourseModel Model)
        {
            if(ModelState.IsValid)
            {
                StringBuilder answerSet = new StringBuilder();
                foreach(var question in Model.Questions)
                {
                    if(!string.IsNullOrWhiteSpace(question.selectedAnswer))
                    {
                        answerSet.Append(question.selectedAnswer + ",");
                    } 
                }
                answerSet.Remove(answerSet.Length - 1, 1);
                CourseUserUpdateRequest cuur = new CourseUserUpdateRequest()
                {
                    email = MvcApplication.userEmail,
                    courseCode = Model.CourseCode,
                    RoleCode = "Student",
                    answerSet = answerSet.ToString()
                };
                bool result = _courseUserCom.UpdateCourseUser(cuur).Result;
                if(result)
                {
                    MvcApplication.courses.Add(Model.CourseCode, Model.CourseName);
                    MvcApplication.courseDescription.Add(Model.CourseCode, Model.CourseDescription);
                    return RedirectToAction("Student", "Course");
                }
                else
                {
                    ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
                    return View(Model);
                }
            }
            ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
            return View(Model);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.User = MvcApplication.userName;
            CreateCourseModel ccm = new CreateCourseModel();
            ccm.Users = new List<Models.CourseUser>() { new Models.CourseUser() { emailId = MvcApplication.userEmail, role = Models.Role.Teacher } };
            //ccm.DesiredSkillSets = new List<Skill>();
            ccm.Questions = new List<Models.Question>();
            return View(ccm);
        }

        public PartialViewResult BlankEditorRow()
        {
            return PartialView("_CourseUsers", new Models.CourseUser());
        }

        public PartialViewResult BlankSkillRow()
        {
            return PartialView("_CourseSkill", new Skill());
        }

        public PartialViewResult BlankQuestionRow()
        {
            return PartialView("_CourseQuestion", new Models.Question());
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
                    CourseDescription = model.CourseDescription,
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

                if(model.Users != null && model.Users.Count > 0)
                {
                    foreach(var user in model.Users)
                    {
                        car.userList.Add(new CourseNewUser()
                        {
                            emailId = user.emailId,
                            roleCode = user.role.ToString()
                        });
                    }
                }
                
                bool result = _courseCom.AddCourse(car).Result;
                if (result) //Course is added, now generate intelligent question set and add questionnaire
                {
                    QuestionnaireAddRequest qar = new QuestionnaireAddRequest()
                    {
                         IsATemplate = false,
                         QuestionnaireCode = DateTime.UtcNow.ToString("MMddyyHmmss"),
                         Questions = new List<DomainDto.Question>()
                    };
                    List<string> timeZones = TimeZoneInfo.GetSystemTimeZones().Select(x => x.DisplayName).ToList();
                    qar.Questions.Add(new DomainDto.Question()
                    {
                         questionText = "In what timezone are you mostly available?",
                         questionType = "MultipleChoice",
                         answerChoices = timeZones
                    });
                    List<string> timeSlots = new List<string>()
                    {
                        "6:00 AM - 9:00 AM",
                        "9:00 AM - 12:00 PM",
                        "12:00 PM - 3:00 PM",
                        "3:00 PM - 6:00 PM",
                        "6:00 PM - 9:00 PM",
                        "9:00 PM - 12:00 AM",
                        "Anytime",
                        "I am not available"

                    };
                    qar.Questions.Add(new DomainDto.Question()
                    {
                        questionText = "During weekday, what time are you available for group calls?",
                        questionType = "MultipleChoice",
                        answerChoices = timeSlots
                    });
                    qar.Questions.Add(new DomainDto.Question()
                    {
                        questionText = "During weekends, what time are you available for group calls?",
                        questionType = "MultipleChoice",
                        answerChoices = timeSlots
                    });

                    if(model.GenerateIntelligentQuestionnaire)
                    {
                        if(model.DesiredSkillSets != null)
                        {
                            foreach(var skl in model.DesiredSkillSets.Split(','))
                            {
                                qar.Questions.Add(new DomainDto.Question()
                                    {
                                        questionText = "What is your expertise in " + skl,
                                        questionType = "MultipleChoice",
                                        answerChoices = new List<string>() { "Beginner", "Intermediate", "Expert"}
                                    });
                            }
                        }
                    }

                    if(model.Questions != null && model.Questions.Count > 0)
                    {
                        foreach(var q in model.Questions)
                        {
                            qar.Questions.Add(new DomainDto.Question()
                                {
                                    questionType = q.QuestionType,
                                    questionText  = q.QuestionText,
                                    answerChoices = q.AnswerChoices.Split(',').ToList()
                                });
                        }
                    }
                    bool res = _questionnaireCom.AddQuestionnaire(qar).Result;
                    if(res)//Questionnaire is added, update course with questionnaire
                    {
                        CourseUpdateRequest cur = new CourseUpdateRequest()
                        {
                            CourseCode = model.CourseCode,
                            QuestionnaireCode = qar.QuestionnaireCode
                        };
                        bool resp = _courseCom.UpdateCourse(cur).Result;
                        if(!resp)
                        {
                            ModelState.AddModelError("", "Oops! Course was added, but someting wrong happened while adding questionnaire to course");
                            return View(model);
                        }
                    }
                    MvcApplication.courses.Add(model.CourseCode, model.CourseName);
                    MvcApplication.courseDescription.Add(model.CourseCode, model.CourseDescription);
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

        public ActionResult CourseTeacher(string courseId)
        {
            CourseGetResponse cgr = _courseCom.GetCourse(courseId).Result;
            DisplayCourseModel dcm = new DisplayCourseModel();
            if(cgr != null)
            {
                dcm.CourseCode = cgr.CourseCode;
                dcm.CourseDescription = cgr.CourseDescription;
                dcm.CourseName = cgr.CourseName;
                dcm.DesiredSkillSets = cgr.DesiredSkillSets;
                dcm.GroupSize = (int)cgr.GroupSize;
                dcm.GroupType = cgr.GroupType;
                dcm.PreferSimiliarSkillSet = (bool)cgr.PreferSimiliarSkillSet;
                dcm.Users = new List<Models.DisplayCourseUser>();
                dcm.Questions = new List<Models.DsiplayQuestion>();
            }
            foreach(var user in cgr.UserList)
            {
                dcm.Users.Add(new DisplayCourseUser()
                    {
                        emailId = user.EmailID,
                        name = user.Name,
                        role = user.RoleCode
                    });
            }

            QuestionnaireGetResponse qgr = _questionnaireCom.GetQuestionnaire(cgr.QuestionnaireCode).Result;

            if(qgr != null)
            {
                foreach(var q in qgr.Questions)
                {
                    dcm.Questions.Add(new Models.DsiplayQuestion()
                        {
                             QuestionText = q.questionText,
                              QuestionType = q.questionType,
                               AnswerChoices = q.answerChoices
                        });
                }
            }
            return View(dcm);
        }
    }
}