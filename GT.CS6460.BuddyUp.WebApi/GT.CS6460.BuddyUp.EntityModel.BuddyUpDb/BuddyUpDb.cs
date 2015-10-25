using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GT.CS6460.BuddyUp.EntityModel.BuddyUpDb
{
    public partial class BuddyUpDb : DbContext
    {
        public BuddyUpDb()
            : base("BuddyUpDb")
        {
            //Database.SetInitializer(null as IDatabaseInitializer<CoreDb>);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuddyUpDb, Migrations.Configuration>());
        }

        public BuddyUpDb(System.Data.Common.DbConnection dbConnection)
            : base(dbConnection, true)
        {
            //Database.SetInitializer(null as IDatabaseInitializer<CoreDb>);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuddyUpDb, Migrations.Configuration>());
        }
    }
}
