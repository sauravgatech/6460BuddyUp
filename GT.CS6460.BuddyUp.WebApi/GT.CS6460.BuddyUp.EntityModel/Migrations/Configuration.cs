using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;

namespace GT.CS6460.BuddyUp.EntityModel.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<GT.CS6460.BuddyUp.EntityModel.BuddyUpDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "GT.CS6460.BuddyUp.EntityModel.BuddyUpDb.BuddyUpDb";
        }

        protected override void Seed(GT.CS6460.BuddyUp.EntityModel.BuddyUpDb db)
        {
            db.Roles.AddOrUpdate(x => x.RoleId, new Role() { RoleId = 1, RoleCode = "Admin", RoleDescription = "System Administrator" });
            db.Roles.AddOrUpdate(x => x.RoleId, new Role() { RoleId = 2, RoleCode = "Teacher", RoleDescription = "Course Teacher" });
            db.Roles.AddOrUpdate(x => x.RoleId, new Role() { RoleId = 3, RoleCode = "TA", RoleDescription = "Teaching Assistant" });
            db.Roles.AddOrUpdate(x => x.RoleId, new Role() { RoleId = 4, RoleCode = "Student", RoleDescription = "Student" });

            db.GroupTypes.AddOrUpdate(x => x.GroupTypeId, new GroupType() { GroupTypeId = 1, GroupTypeCode = "Study", Description = "Study Groups" });
            db.GroupTypes.AddOrUpdate(x => x.GroupTypeId, new GroupType() { GroupTypeId = 2, GroupTypeCode = "OpenProject", Description = "Open Project Group" });
            db.GroupTypes.AddOrUpdate(x => x.GroupTypeId, new GroupType() { GroupTypeId = 3, GroupTypeCode = "ClosedProject", Description = "Closed Project Group" });

            db.QuestionTypes.AddOrUpdate(x => x.QuestionTypeId, new QuestionType() { QuestionTypeId = 1, Type = "MultipleChoice" });
            db.QuestionTypes.AddOrUpdate(x => x.QuestionTypeId, new QuestionType() { QuestionTypeId = 2, Type = "FillUpTheBlank" });

            db.UserProfiles.AddOrUpdate(x => x.UserId,
                new UserProfile() { UserId = 1, isAdmin=true, FirstName="Administrator", EmailId = "admin@buddyup.com", HashedPassword = "wuH/oOzrqWkKAGzJUSxwApDZ/U9fcX/ELDb6pGbyRL4=", LastPasswordChangeDate = DateTime.UtcNow, PasswordExpired = false });

            db.Courses.AddOrUpdate(x => x.CourseId,
                new Course() { CourseId = 1, CourseCode = "Default", PrefGroupTypeId = 1, CourseName = "Daefault Course"  });
            
            db.CourseUserRoles.AddOrUpdate(x => new { x.CourseId, x.UserId, x.RoleId }, new CourseUserRole() { CourseId = 1, RoleId = 1, UserId = 1 });

        }
    }
}
