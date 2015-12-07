using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.CS6460.BuddyUp.DomainDto;
using GT.CS6460.BuddyUp.Platform.Common;
using GT.CS6460.BuddyUp.Platform.Repository;
using GT.CS6460.BuddyUp.EntityModel;
using Microsoft.Practices.Unity;

namespace GT.CS6460.BuddyUp.DomainModel
{
    public class CourseMaintenance : ICourse
    {
        private IRepository<Course> _repCourse;
        private IRepository<CourseUserRole> _repCourseUserRole;
        private IRepository<UserProfile> _repUserProfile;
        private IRepository<EntityModel.Role> _repRole;
        private IRepository<EntityModel.Questionnaire> _repQuestionnaire;
        private IRepository<GroupType> _repGroupType;
        
        private IUnitOfWork _uow;
        
        private DomainModelResponse _courseResponse = new DomainModelResponse();

        public CourseMaintenance([Dependency("buddyup")] IUnitOfWork uow)
        {
            _uow = uow;
        }

        [InjectionMethod]
        public void Initialize(IRepository<Course> repCourse, 
                                IRepository<CourseUserRole> repCourseUserRole,
                                IRepository<UserProfile> repUserProfile,
                                IRepository<EntityModel.Role> repRole,
                                IRepository<EntityModel.Questionnaire> repQuestionnaire,
                                IRepository<GroupType> repGroupType)
        {
            _repCourse = repCourse.Use(_uow);
            _repCourseUserRole = repCourseUserRole.Use(_uow);
            _repUserProfile = repUserProfile.Use(_uow);
            _repRole = repRole.Use(_uow);
            _repQuestionnaire = repQuestionnaire.Use(_uow);
            _repGroupType = repGroupType.Use(_uow);
        }

        public IEnumerable<CourseGetResponse> Get(string courseCode)
        {
            IEnumerable<Course> courses = _repCourse.Get(filter: u => (u.CourseCode == courseCode), includes: "Questionnaire,CourseUserRoles,GroupType");
            List<CourseGetResponse> CourseGetResponses = new List<CourseGetResponse>();
            foreach (Course course in courses)
            {
                CourseGetResponse dr = new CourseGetResponse()
                {
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName,
                    QuestionnaireCode = course.Questionnaire.QuestionnaireCode,
                    CourseDescription = course.CourseDescription,
                    DesiredSkillSets = course.DesiredSkillSets,
                    GroupSize = course.PrefGroupSize,
                    GroupType = course.GroupType.GroupTypeCode,
                    PreferSimiliarSkillSet = course.SimilarSkillSetPreffered,
                    UserList = new List<CourseUser>(),
                    CourseGroups = new List<CourseGroups>()
                };
                foreach(var cur in course.CourseUserRoles)
                {
                    CourseUser cu = new CourseUser()
                    {
                        EmailID = cur.UserProfile.EmailId,
                        Name = cur.UserProfile.FirstName + " " + cur.UserProfile.LastName,
                        RoleCode = cur.Role.RoleCode,
                    };
                    if(cur.Group != null)
                    {
                        if (!dr.CourseGroups.Any(x => x.GroupCode == cur.Group.GroupCode))
                        {
                            CourseGroups cg = new CourseGroups()
                            {
                                GroupCode = cur.Group.GroupCode,
                                GroupName = cur.Group.GroupName,
                                Objective = cur.Group.Objective,
                                TimeZone = cur.Group.TimeZone
                            };
                            dr.CourseGroups.Add(cg);
                        }
                    }
                    dr.UserList.Add(cu);
                }
                CourseGetResponses.Add(dr);
            }
            return CourseGetResponses;
        }

        public IEnumerable<CourseGetResponse> Get()
        {
            IEnumerable<Course> courses = _repCourse.Get(includes: "Questionnaire");
            List<CourseGetResponse> CourseGetResponses = new List<CourseGetResponse>();
            foreach (Course course in courses)
            {
                CourseGetResponse dr = new CourseGetResponse()
                {
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName,
                    QuestionnaireCode = course.Questionnaire != null ? course.Questionnaire.QuestionnaireCode :  null
                };
                CourseGetResponses.Add(dr);
            }
            return CourseGetResponses;
        }


        public DomainModelResponse Add(CourseAddRequest request)
        {
            GroupType gt = _repGroupType.Get(filter: x => x.GroupTypeCode == request.GroupType).FirstOrDefault();

            Course course = new Course()
            {
                CourseCode = request.CourseCode,
                CourseName = request.CourseName,
                CourseDescription = request.CourseDescription,
                LastChangedTime = DateTime.UtcNow,
                DesiredSkillSets = request.DesiredSkillSets,
                GroupType = gt,
                PrefGroupTypeId = gt.GroupTypeId,
                PrefGroupSize = request.GroupSize,
                SimilarSkillSetPreffered = request.PreferSimiliarSkillSet
            };

            _repCourse.Add(course);
            _uow.Commit();
            course = _repCourse.Get(filter: f => f.CourseCode == request.CourseCode).FirstOrDefault();

            if (request.userList != null)
            {
                List<string> roleCodes = request.userList.Select(x => x.roleCode).ToList();
                List<string> emailIds = request.userList.Select(x => x.emailId).ToList();

                List<EntityModel.Role> roles = _repRole.Get(filter: f => roleCodes.Contains(f.RoleCode)).ToList();
                List<UserProfile> userProfiles = _repUserProfile.Get(filter: f => emailIds.Contains(f.EmailId)).ToList();

                foreach(var user in request.userList)
                {
                    CourseUserRole cur = new CourseUserRole()
                    {
                        CourseId = course.CourseId,
                        Course = course,
                        Role = roles.Where(x => x.RoleCode == user.roleCode).FirstOrDefault(),
                        RoleId = roles.Where(x => x.RoleCode == user.roleCode).FirstOrDefault().RoleId,
                        UserId = userProfiles.Where(x => x.EmailId == user.emailId).FirstOrDefault().UserId,
                        UserProfile = userProfiles.Where(x => x.EmailId == user.emailId).FirstOrDefault(),
                        LastChangedTime = DateTime.UtcNow
                    };
                    _repCourseUserRole.Add(cur);
                }
                _uow.Commit();
            }
            _courseResponse.addResponse("Add", MessageCodes.InfoCreatedSuccessfully, "Course : " + request.CourseCode);
            return _courseResponse;
        }

        public DomainModelResponse Update(CourseUpdateRequest request)
        {
            Course course = _repCourse.Get(filter: f => f.CourseCode == request.CourseCode).FirstOrDefault();
            bool updateCourse = false;
            if(request.CourseName != null) //Course name update
            {
                course.CourseName = request.CourseName;
                updateCourse = true;
            }
            if (request.CourseDescription != null) 
            {
                course.CourseDescription = request.CourseDescription;
                updateCourse = true;
            }

            if(request.QuestionnaireCode != null)
            {
                EntityModel.Questionnaire questionnaire = _repQuestionnaire.Get(filter: f => f.QuestionnaireCode == request.QuestionnaireCode).FirstOrDefault();
                course.QuestionnaireId = questionnaire.QuestionnaireId;
                course.Questionnaire = questionnaire;
                updateCourse = true;
            }

            if(updateCourse)
                _repCourse.Update(course);

            if(request.CourseNewUsers != null)
            {
                List<string> roleCodes = request.CourseNewUsers.Select(x => x.roleCode).ToList();
                List<string> emailIds = request.CourseNewUsers.Select(x => x.emailId).ToList();

                List<EntityModel.Role> roles = _repRole.Get(filter: f => roleCodes.Contains(f.RoleCode)).ToList();
                List<UserProfile> userProfiles = _repUserProfile.Get(filter: f => emailIds.Contains(f.EmailId)).ToList();

                foreach (var user in request.CourseNewUsers)
                {
                    CourseUserRole cur = new CourseUserRole()
                    {
                        CourseId = course.CourseId,
                        Course = course,
                        Role = roles.Where(x => x.RoleCode == user.roleCode).FirstOrDefault(),
                        RoleId = roles.Where(x => x.RoleCode == user.roleCode).FirstOrDefault().RoleId,
                        UserId = userProfiles.Where(x => x.EmailId == user.emailId).FirstOrDefault().UserId,
                        UserProfile = userProfiles.Where(x => x.EmailId == user.emailId).FirstOrDefault(),
                        LastChangedTime = DateTime.UtcNow
                    };
                    _repCourseUserRole.Add(cur);
                }
            }

            if (request.CourseDeleteUsers != null)
            {
                List<string> roleCodes = request.CourseDeleteUsers.Select(x => x.roleCode).ToList();
                List<string> emailIds = request.CourseDeleteUsers.Select(x => x.emailId).ToList();

                List<EntityModel.Role> roles = _repRole.Get(filter: f => roleCodes.Contains(f.RoleCode)).ToList();
                List<UserProfile> userProfiles = _repUserProfile.Get(filter: f => emailIds.Contains(f.EmailId)).ToList();

                foreach (var user in request.CourseDeleteUsers)
                {
                    int RoleId = roles.Where(x => x.RoleCode == user.roleCode).FirstOrDefault().RoleId;
                    int UserId = userProfiles.Where(x => x.EmailId == user.emailId).FirstOrDefault().UserId;

                    CourseUserRole cur = _repCourseUserRole.Get(filter: f => f.RoleId == RoleId && f.CourseId == course.CourseId && f.UserId == UserId).FirstOrDefault();
                    _repCourseUserRole.Delete(cur);
                }
            }

            _uow.Commit();
            _courseResponse.addResponse("Update", MessageCodes.InfoSavedSuccessfully, "Course : " + request.CourseCode);
            return _courseResponse;
        }

        public DomainModelResponse Delete(string courseCode)
        {
            return new DomainModelResponse();
        }
    }
}
