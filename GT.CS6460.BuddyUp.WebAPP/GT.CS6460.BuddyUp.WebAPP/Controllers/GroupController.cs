using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT.CS6460.BuddyUp.Platform.Communicator;
using GT.CS6460.BuddyUp.WebAPP.Models;
using GT.CS6460.BuddyUp.DomainDto;
using System.Threading.Tasks;

namespace GT.CS6460.BuddyUp.WebAPP.Controllers
{
    public class GroupController : Controller
    {
        GroupCommunicator _groupCom = new GroupCommunicator();
        private CourseCommunicator _courseCom = new CourseCommunicator();
        private PostCommunicator _postCom = new PostCommunicator();
        private UserCommunicator _userCom = new UserCommunicator();
        // GET: Group
        public ActionResult GroupDetail(string groupCode)
        {
            MvcApplication.currentGroupCode = groupCode;
            GroupDetailModel gdm = null;
            GroupGetResponse ggr = _groupCom.GetGroup(groupCode).Result;
            if(ggr!=null)
            {
                gdm = new GroupDetailModel()
                {
                    CourseCode = ggr.CourseCode,
                    GroupCode = ggr.GroupCode,
                    GroupName = ggr.GroupName,
                    GroupTypeCode = ggr.GroupTypeCode,
                    Objective = ggr.Objective,
                    TimeZone = ggr.TimeZone,
                    UserList = new List<GroupUserModel>(),
                    GroupPosts = new List<PostModel>()
                };
                foreach(var user in ggr.UserList)
                {
                    gdm.UserList.Add(new GroupUserModel()
                        {
                            emailId = user.emailId,
                            name = user.name
                        });
                }
                foreach(var posts in ggr.GroupPosts)
                {
                    PostModel pm = new PostModel()
                        {
                            PostText = posts.PostText,
                            TimePosted = posts.TimePosted,
                            UserName = posts.UserName,

                        };
                    if(posts.ChildPosts != null && posts.ChildPosts.Count > 0)
                    {
                        pm.ChildPosts = new List<PostModel>();
                        foreach(var cp in posts.ChildPosts)
                        {
                            pm.ChildPosts.Add(new PostModel()
                            {
                                PostText = cp.PostText,
                                TimePosted = cp.TimePosted,
                                UserName = cp.UserName
                                
                            });
                        }
                    }
                    gdm.GroupPosts.Add(pm);
                }
            }
            return View(gdm);
        }

        [HttpPost]
        public async Task<ActionResult> GroupDetail(GroupDetailModel model)
        {
            return View(model);
        }

        public ActionResult GroupSummary(string courseCode)
        {
            GroupListModel glm = new GroupListModel();
            MvcApplication.currentCourseCode = courseCode;
            glm.CourseCode = courseCode;
            glm.SuggestedGroups = null;
            glm.AllGroups = null;
            GroupSummaryForUser gsfu = _groupCom.GetGroupSummary(MvcApplication.userEmail, courseCode).Result;
            if(gsfu != null)
            {
                //if(string.IsNullOrWhiteSpace(gsfu.registeredGroupCode)) //show group summary
                //{
                if(gsfu.registeredGroup != null)
                {
                    glm.registeredGroup = new Models.GroupSummary()
                    {
                        GroupCode = gsfu.registeredGroup.GroupCode,
                        GroupName = gsfu.registeredGroup.GroupName,
                        Objective = gsfu.registeredGroup.Objective,
                        TimeZone = gsfu.registeredGroup.activeTimeZone
                    };
                }
                    if(gsfu.suggestedGroups != null && gsfu.suggestedGroups.Count > 0)
                    {
                        glm.SuggestedGroups = new List<Models.GroupSummary>();
                        foreach(var grp in gsfu.suggestedGroups)
                        {
                            glm.SuggestedGroups.Add(new Models.GroupSummary()
                                {
                                    GroupCode = grp.GroupCode,
                                    GroupName = grp.GroupName,
                                    TimeZone = grp.activeTimeZone,
                                    Objective = grp.Objective
                                });
                        }
                    }
                    if (gsfu.AllGroups != null && gsfu.AllGroups.Count > 0)
                    {
                        glm.AllGroups = new List<Models.GroupSummary>();
                        foreach (var grp in gsfu.AllGroups)
                        {
                            glm.AllGroups.Add(new Models.GroupSummary()
                            {
                                GroupCode = grp.GroupCode,
                                GroupName = grp.GroupName,
                                TimeZone = grp.activeTimeZone,
                                Objective = grp.Objective
                            });
                        }
                    }
                    return View(glm);
                //}
                //else//redirect to group detail page
                //{
                //    return RedirectToAction("GroupDetail", "Group", routeValues: new { groupCode = gsfu.registeredGroupCode });
                //}
                
            }
            ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
            return View(glm);
        }


        public ActionResult Create(string courseCode)
        {
            GroupCreateModel gcm = new GroupCreateModel();
            CourseGetResponse cgr = _courseCom.GetCourse(courseCode).Result;
            if(cgr != null)
            {
                gcm.GroupTypeCode = cgr.GroupType;
                if (cgr.GroupSize.HasValue)
                    gcm.MaxNumberOfUsers = cgr.GroupSize;
            }
            gcm.timeZones = TimeZoneInfo.GetSystemTimeZones().Select(x => x.DisplayName).ToList();
            gcm.CourseCode = courseCode;
            return View(gcm);
        }


        public ActionResult NewPost()
        {
            return PartialView("_GroupPost", new Models.PostModel() { UserName = MvcApplication.userName, TimePosted = DateTime.UtcNow });
        }

        [HttpPost]
        public ActionResult NewPost(PostModel model)
        {
            if(ModelState.IsValid)
            {
                PostAddRequest par = new PostAddRequest()
                {
                    PostText = model.PostText,
                    TimePosted = DateTime.UtcNow,
                    GroupCode = MvcApplication.currentGroupCode,
                    UserName = MvcApplication.userName
                };
                bool result = _postCom.AddPost(par).Result;
                if(result)
                {
                    return RedirectToAction("GroupDetail", "Group", routeValues: new { groupCode = MvcApplication.currentGroupCode });
                }
            }
            ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GroupCreateModel Model)
        {
            if(ModelState.IsValid)
            {
                GroupAddRequest gar = new GroupAddRequest()
                {
                    CourseCode = Model.CourseCode,
                    GroupCode = Model.CourseCode + DateTime.UtcNow.ToString("MMddyyHmmss"),
                    GroupName = Model.GroupName,
                    GroupTypeCode = Model.GroupTypeCode,
                    Objective = Model.Objective,
                    TimeZone = Model.TimeZone,
                    userList = new List<string>() { MvcApplication.userEmail }
                };
                bool resp = _groupCom.AddGroup(gar).Result;
                if(resp)
                    return RedirectToAction("GroupDetail", "Group", routeValues: new { groupCode = gar.GroupCode });
            }
            ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
            return View(Model);
        }


        public ActionResult LeaveGroup(string groupCode, string courseCode)
        {
            UpdateUserGroup uug = new UpdateUserGroup()
            {
                courseCode = courseCode,
                GroupCode = groupCode,
                emailId = MvcApplication.userEmail
            };
            bool result = _userCom.RemoveUserFromGroup(uug).Result;
            if(result)
                return RedirectToAction("GroupSummary", "Group", routeValues: new { courseCode = courseCode });
            else
            {
                ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
                return RedirectToAction("GroupDetail", "Group", routeValues: new { groupCode = groupCode });
            }

        }

        public ActionResult JoinGroup(string groupCode, string courseCode)
        {
            UpdateUserGroup uug = new UpdateUserGroup()
            {
                courseCode = courseCode,
                GroupCode = groupCode,
                emailId = MvcApplication.userEmail
            };
            bool result = _userCom.AddUserToGroup(uug).Result;
            if (result)
                return RedirectToAction("GroupDetail", "Group", routeValues: new { groupCode = groupCode });
                
            else
            {
                ModelState.AddModelError("", "Oops! Something wrong happened! Please try again.");
                return RedirectToAction("GroupSummary", "Group", routeValues: new { courseCode = courseCode });
            }

        }


        //// GET: Group/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Group/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Group/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Group/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Group/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Group/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Group/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
