using System;
using System.Data.Entity;

namespace GT.CS6460.BuddyUp.Platform.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        DbContext Context { get; }
    }
}
