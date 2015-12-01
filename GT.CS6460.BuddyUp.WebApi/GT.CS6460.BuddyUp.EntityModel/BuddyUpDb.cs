using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GT.CS6460.BuddyUp.EntityModel
{
    public partial class BuddyUpDb : DbContext
    {
        public BuddyUpDb()
            : base("BuddyUpDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuddyUpDb, Migrations.Configuration>());
        }

        public BuddyUpDb(System.Data.Common.DbConnection dbConnection)
            : base(dbConnection, true)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuddyUpDb, Migrations.Configuration>());
        }

        public DbSet<AnswerChoice> AnswerChoices { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseUserRole> CourseUserRoles { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupType> GroupTypes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<SessionToken> SessionTokens { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
