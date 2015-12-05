namespace GT.CS6460.BuddyUp.EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerChoices",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Answer = c.String(maxLength: 128),
                        QuestionId = c.Int(nullable: false),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(maxLength: 128),
                        QuestionTypeId = c.Int(nullable: false),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, cascadeDelete: true)
                .Index(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QuestionTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 24),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(maxLength: 24),
                        CourseName = c.String(maxLength: 128),
                        CourseDescription = c.String(maxLength: 2048),
                        QuestionnaireId = c.Int(),
                        PrefGroupTypeId = c.Int(),
                        PrefGroupSize = c.Int(),
                        SimilarSkillSetPreffered = c.Boolean(),
                        DesiredSkillSets = c.String(),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.GroupTypes", t => t.PrefGroupTypeId)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId)
                .Index(t => t.QuestionnaireId)
                .Index(t => t.PrefGroupTypeId);
            
            CreateTable(
                "dbo.CourseUserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GroupId = c.Int(),
                        AnswerSet = c.String(),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupCode = c.String(maxLength: 24),
                        GroupName = c.String(maxLength: 128),
                        Objective = c.String(maxLength: 2048),
                        TimeZone = c.String(maxLength: 128),
                        GroupTypeId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.GroupTypes", t => t.GroupTypeId, cascadeDelete: true)
                .Index(t => t.GroupTypeId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.GroupTypes",
                c => new
                    {
                        GroupTypeId = c.Int(nullable: false, identity: true),
                        GroupTypeCode = c.String(maxLength: 24),
                        Description = c.String(maxLength: 128),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.GroupTypeId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostText = c.String(maxLength: 512),
                        UserName = c.String(maxLength: 32),
                        TimePosted = c.DateTime(nullable: false),
                        ParentId = c.Int(),
                        GroupId = c.Int(nullable: false),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleCode = c.String(maxLength: 24),
                        RoleDescription = c.String(maxLength: 128),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(maxLength: 128),
                        HashedPassword = c.String(maxLength: 128),
                        LastPasswordChangeDate = c.DateTime(nullable: false),
                        PasswordExpired = c.Boolean(),
                        SecurityQuestion = c.String(maxLength: 128),
                        HashedAnswer = c.String(maxLength: 128),
                        FirstName = c.String(maxLength: 64),
                        LastName = c.String(maxLength: 64),
                        isAdmin = c.Boolean(),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.EmailId, unique: true);
            
            CreateTable(
                "dbo.SessionTokens",
                c => new
                    {
                        Token = c.String(nullable: false, maxLength: 128),
                        CreationTimeUtc = c.DateTime(nullable: false),
                        LastActivityTimeUtc = c.DateTime(nullable: false),
                        HasPasswordExpired = c.Boolean(),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Token)
                .ForeignKey("dbo.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        QuestionnaireId = c.Int(nullable: false, identity: true),
                        QuestionnaireCode = c.String(),
                        QuestionSet = c.String(),
                        IsATemplate = c.Boolean(),
                        LastChangedBy = c.String(maxLength: 32),
                        LastChangedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.QuestionnaireId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Courses", "PrefGroupTypeId", "dbo.GroupTypes");
            DropForeignKey("dbo.CourseUserRoles", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.SessionTokens", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.CourseUserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.CourseUserRoles", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Posts", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "GroupTypeId", "dbo.GroupTypes");
            DropForeignKey("dbo.Groups", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseUserRoles", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AnswerChoices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropIndex("dbo.SessionTokens", new[] { "UserId" });
            DropIndex("dbo.UserProfiles", new[] { "EmailId" });
            DropIndex("dbo.Posts", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "CourseId" });
            DropIndex("dbo.Groups", new[] { "GroupTypeId" });
            DropIndex("dbo.CourseUserRoles", new[] { "GroupId" });
            DropIndex("dbo.CourseUserRoles", new[] { "CourseId" });
            DropIndex("dbo.CourseUserRoles", new[] { "UserId" });
            DropIndex("dbo.CourseUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Courses", new[] { "PrefGroupTypeId" });
            DropIndex("dbo.Courses", new[] { "QuestionnaireId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropIndex("dbo.AnswerChoices", new[] { "QuestionId" });
            DropTable("dbo.Questionnaires");
            DropTable("dbo.SessionTokens");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Roles");
            DropTable("dbo.Posts");
            DropTable("dbo.GroupTypes");
            DropTable("dbo.Groups");
            DropTable("dbo.CourseUserRoles");
            DropTable("dbo.Courses");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.AnswerChoices");
        }
    }
}
