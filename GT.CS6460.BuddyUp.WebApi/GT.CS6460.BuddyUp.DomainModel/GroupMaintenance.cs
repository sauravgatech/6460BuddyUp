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
    public class GroupMaintenance : IGroup
    {
        private IRepository<Group> _repGroup;
        private IRepository<GroupType> _repGroupType;
        private IRepository<Course> _repCourse;
        private IRepository<UserProfile> _repUserProfile;
        private IRepository<CourseUserRole> _repCourseUserRole;
        
        private IUnitOfWork _uow;
        
        private DomainModelResponse _groupResponse = new DomainModelResponse();

        public GroupMaintenance([Dependency("buddyup")] IUnitOfWork uow)
        {
            _uow = uow;
        }

        [InjectionMethod]
        public void Initialize(IRepository<Group> repGroup,
                                IRepository<GroupType> repGroupType,
                                IRepository<Course> repCourse,
                                IRepository<UserProfile> repUserProfile,
                                IRepository<CourseUserRole> repCourseUserRole)
        {
            _repCourse = repCourse.Use(_uow);
            _repGroup = repGroup.Use(_uow);
            _repGroupType = repGroupType.Use(_uow);
            _repUserProfile = repUserProfile.Use(_uow);
            _repCourseUserRole = repCourseUserRole.Use(_uow);
        }

        public IEnumerable<GroupGetResponse> Get(string groupCode = "")
        {
            List<Group> groups = _repGroup.Get(filter: f => (f.GroupCode == groupCode || groupCode == ""), includes: "GroupType,CourseUserRole,Course,UserProfile").ToList();
            List<GroupGetResponse> groupGetResponses = new List<GroupGetResponse>();
            foreach(Group grp in groups)
            {
                GroupGetResponse ggr = new GroupGetResponse()
                {
                    GroupCode = grp.GroupCode,
                    GroupName = grp.GroupName,
                    Objective = grp.Objective,
                    TimeZone = grp.TimeZone,
                    UserList = new List<string>(),
                    GroupTypeCode = grp.GroupType.GroupTypeCode,
                    CourseCode = grp.CourseUserRoles.First().Course.CourseCode
                };
                foreach(var cur in grp.CourseUserRoles)
                {
                    ggr.UserList.Add(cur.UserProfile.EmailId);
                }
                groupGetResponses.Add(ggr);
            }
            return groupGetResponses;
        }

        public DomainModelResponse Add(GroupAddRequest request)
        {
            Group grp = new Group()
            {
                GroupCode = request.GroupCode,
                GroupName = request.GroupName,
                Objective = request.Objective,
                TimeZone = request.TimeZone
            };

            GroupType gt = _repGroupType.Get(filter: f => f.GroupTypeCode == request.GroupTypeCode).FirstOrDefault();

            grp.GroupTypeId = gt.GroupTypeId;
            grp.GroupType = gt;
            _repGroup.Add(grp);
            _uow.Commit();
            grp = _repGroup.Get(filter: f => f.GroupCode == request.GroupCode).FirstOrDefault();

            Course crs = _repCourse.Get(filter: f => f.CourseCode == request.CourseCode).FirstOrDefault();
            
            if (request.userList != null)
            {
                List<int> users = _repUserProfile.Get(filter: f => request.userList.Contains(f.EmailId)).Select(x => x.UserId).ToList();
                List<CourseUserRole> Curs = _repCourseUserRole.Get(filter: f => f.CourseId == crs.CourseId && users.Contains(f.UserId)).ToList();
                foreach (CourseUserRole cur in Curs)
                {
                    cur.GroupId = grp.GroupId;
                    cur.Group = grp;
                    _repCourseUserRole.Update(cur);
                }
            }
            _uow.Commit();
            _groupResponse.addResponse("Add", MessageCodes.InfoCreatedSuccessfully, "Group : " + request.GroupCode);
            return _groupResponse;
        }

        public DomainModelResponse Update(GroupUpdateRequest request)
        {
            Group grp = _repGroup.Get(filter: f => f.GroupCode == request.GroupCode).FirstOrDefault();

            if(string.IsNullOrWhiteSpace(request.GroupName))
            {
                grp.GroupName = request.GroupName;
            }

            if (string.IsNullOrWhiteSpace(request.Objective))
            {
                grp.Objective = request.Objective;
            }

            if (string.IsNullOrWhiteSpace(request.TimeZone))
            {
                grp.TimeZone = request.TimeZone;
            }

            if (string.IsNullOrWhiteSpace(request.GroupTypeCode))
            {
                GroupType gt = _repGroupType.Get(filter: f => f.GroupTypeCode == request.GroupTypeCode).FirstOrDefault();
                grp.GroupTypeId = gt.GroupTypeId;
                grp.GroupType = gt;
            }

            Course crs = grp.CourseUserRoles.FirstOrDefault().Course;

            if (request.newUserList != null)
            {
                List<int> users = _repUserProfile.Get(filter: f => request.newUserList.Contains(f.EmailId)).Select(x => x.UserId).ToList();
                List<CourseUserRole> Curs = _repCourseUserRole.Get(filter: f => f.CourseId == crs.CourseId && users.Contains(f.UserId)).ToList();
                foreach (CourseUserRole cur in Curs)
                {
                    cur.GroupId = grp.GroupId;
                    cur.Group = grp;
                    _repCourseUserRole.Update(cur);
                }
            }

            if (request.removeUserList != null)
            {
                List<int> users = _repUserProfile.Get(filter: f => request.removeUserList.Contains(f.EmailId)).Select(x => x.UserId).ToList();
                List<CourseUserRole> Curs = _repCourseUserRole.Get(filter: f => f.CourseId == crs.CourseId && users.Contains(f.UserId)).ToList();
                foreach (CourseUserRole cur in Curs)
                {
                    cur.GroupId = null;
                    cur.Group = null;
                    _repCourseUserRole.Update(cur);
                }
            }
            _uow.Commit();
            _groupResponse.addResponse("Update", MessageCodes.InfoSavedSuccessfully, "Group : " + request.GroupCode);
            return _groupResponse;
        }

        public DomainModelResponse Delete(string groupCode)
        {
            return new DomainModelResponse();
        }
    }
}
