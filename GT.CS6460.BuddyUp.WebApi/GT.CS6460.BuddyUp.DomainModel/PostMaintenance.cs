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
    public class PostMaintenance : IPost
    {
        private IRepository<Group> _repGroup;
        private IRepository<GroupType> _repGroupType;
        private IRepository<Course> _repCourse;
        private IRepository<UserProfile> _repUserProfile;
        private IRepository<CourseUserRole> _repCourseUserRole;
        private IRepository<EntityModel.Role> _repRole;
        private IRepository<EntityModel.Post> _repPost;
        
        private IUnitOfWork _uow;
        
        private DomainModelResponse _postResponse = new DomainModelResponse();

        public PostMaintenance([Dependency("buddyup")] IUnitOfWork uow)
        {
            _uow = uow;
        }

        [InjectionMethod]
        public void Initialize(IRepository<Group> repGroup,
                                IRepository<GroupType> repGroupType,
                                IRepository<Course> repCourse,
                                IRepository<UserProfile> repUserProfile,
                                IRepository<CourseUserRole> repCourseUserRole,
                                IRepository<EntityModel.Role> repRole,
                                IRepository<EntityModel.Post> repPost)
        {
            _repCourse = repCourse.Use(_uow);
            _repGroup = repGroup.Use(_uow);
            _repGroupType = repGroupType.Use(_uow);
            _repUserProfile = repUserProfile.Use(_uow);
            _repCourseUserRole = repCourseUserRole.Use(_uow);
            _repRole = repRole.Use(_uow);
            _repPost = repPost.Use(_uow);
        }

        public DomainModelResponse AddPost(PostAddRequest request)
        {
            EntityModel.Post parent = null;
            if(request.ParentPostTime != null && !string.IsNullOrWhiteSpace(request.ParentPostUserName))
            {
                parent = _repPost.Get(filter: f => f.TimePosted == request.ParentPostTime && f.UserName == request.ParentPostUserName).FirstOrDefault();
            }

            Group grp = _repGroup.Get(filter: f => f.GroupCode == request.GroupCode).FirstOrDefault();

            EntityModel.Post post = new EntityModel.Post()
            {
                UserName = request.UserName,
                TimePosted = request.TimePosted,
                PostText = request.PostText,
                Group = grp,
                GroupId = grp.GroupId,
                LastChangedTime = DateTime.UtcNow
            };
            if(parent!= null)
            {
                post.ParentId = parent.PostId;
            }
            else
            {
                post.ParentId = null;
            }

            _repPost.Add(post);
            _uow.Commit();
            _postResponse.addResponse("Add", MessageCodes.InfoCreatedSuccessfully, "Post");
            return _postResponse;
        }
    }
}
