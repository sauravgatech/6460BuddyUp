using System;
using System.Data.Entity;

namespace GT.CS6460.BuddyUp.Platform.Repository
{
    public sealed class BuddyUpUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public BuddyUpUnitOfWork()
        {
            _context = new GT.CS6460.BuddyUp.EntityModel.BuddyUpDb();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
