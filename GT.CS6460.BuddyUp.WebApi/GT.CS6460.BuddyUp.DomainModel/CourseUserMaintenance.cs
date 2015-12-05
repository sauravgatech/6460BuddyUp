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
    public class CourseUserMaintenance : ICourseUser
    {
        private IRepository<Course> _repCourse;
        private IRepository<CourseUserRole> _repCourseUserRole;
        private IRepository<UserProfile> _repUserProfile;
        private IRepository<EntityModel.Role> _repRole;
        private IRepository<Group> _repGroup;
        
        private IUnitOfWork _uow;
        
        private DomainModelResponse _courseUserResponse = new DomainModelResponse();

        public CourseUserMaintenance([Dependency("buddyup")] IUnitOfWork uow)
        {
            _uow = uow;
        }

        [InjectionMethod]
        public void Initialize(IRepository<Course> repCourse, 
                                IRepository<CourseUserRole> repCourseUserRole,
                                IRepository<UserProfile> repUserProfile,
                                IRepository<EntityModel.Role> repRole,
                                IRepository<Group> repGroup)
        {
            _repCourse = repCourse.Use(_uow);
            _repCourseUserRole = repCourseUserRole.Use(_uow);
            _repUserProfile = repUserProfile.Use(_uow);
            _repRole = repRole.Use(_uow);
            _repGroup = repGroup.Use(_uow);
        }

        public DomainModelResponse UpdateCourseUserAnswer(CourseUserUpdateRequest request)
        {
            UserProfile up = _repUserProfile.Get(filter: f => f.EmailId == request.email).FirstOrDefault();
            Course course = _repCourse.Get(filter: f => f.CourseCode == request.courseCode).FirstOrDefault();
            EntityModel.Role role = _repRole.Get(filter: f => f.RoleCode == request.RoleCode).FirstOrDefault();

            CourseUserRole cur = _repCourseUserRole.Get(filter: f => f.UserId == up.UserId && f.RoleId == role.RoleId && f.CourseId == course.CourseId).FirstOrDefault();
            bool isAdd = false;
            if(cur == null) //User is nto added
            {
                isAdd = true;
                cur = new CourseUserRole()
                {
                    CourseId = course.CourseId,
                    Course = course,
                    UserId = up.UserId,
                    UserProfile = up,
                    RoleId = role.RoleId,
                    Role = role
                };
            }
            if(!string.IsNullOrWhiteSpace(request.answerSet))
            {
                cur.AnswerSet = request.answerSet;
            }
            if(!string.IsNullOrWhiteSpace(request.GroupCode))
            {
                Group grp = _repGroup.Get(filter: f => f.GroupCode == request.GroupCode).FirstOrDefault();
                cur.GroupId = grp.GroupId;
                cur.Group = grp;
            }
            if (isAdd)
            {
                _repCourseUserRole.Add(cur);
                _courseUserResponse.addResponse("Add", MessageCodes.InfoCreatedSuccessfully, "Course User Role for User : " + request.email);
            }
            else
            {
                _repCourseUserRole.Update(cur);
                _courseUserResponse.addResponse("Update", MessageCodes.InfoSavedSuccessfully, "Course User Role for User : " + request.email);
            }
            _uow.Commit();
            return _courseUserResponse;
        }
    }
}
