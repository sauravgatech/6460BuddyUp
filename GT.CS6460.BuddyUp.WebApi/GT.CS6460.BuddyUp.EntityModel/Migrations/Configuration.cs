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
            db.UserProfiles.AddOrUpdate(x => x.UserId,
                new UserProfile() { UserId = 1, EmailId = "admin@buddyup.com", HashedPassword = "wuH/oOzrqWkKAGzJUSxwApDZ/U9fcX/ELDb6pGbyRL4=", LastPasswordChangeDate = DateTime.UtcNow, PasswordExpired = false });
        }
    }
}
