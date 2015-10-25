using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;

namespace GT.CS6460.BuddyUp.EntityModel.BuddyUpDb.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<GT.CS6460.BuddyUp.EntityModel.BuddyUpDb.BuddyUpDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "GT.CS6460.BuddyUp.EntityModel.BuddyUpDb.BuddyUpDb";
        }

        protected override void Seed(GT.CS6460.BuddyUp.EntityModel.BuddyUpDb.BuddyUpDb db)
        {
            
        }
    }
}
