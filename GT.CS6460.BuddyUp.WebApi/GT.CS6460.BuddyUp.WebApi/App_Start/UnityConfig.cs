using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace GT.CS6460.BuddyUp.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType(typeof(GT.CS6460.BuddyUp.Platform.Repository.IUnitOfWork), typeof(GT.CS6460.BuddyUp.Platform.Repository.BuddyUpUnitOfWork), "buddyup");
            container.RegisterType(typeof(GT.CS6460.BuddyUp.Platform.Repository.IRepository<>), typeof(GT.CS6460.BuddyUp.Platform.Repository.Repository<>));
            container.RegisterType(typeof(GT.CS6460.BuddyUp.DomainModel.ISecurity), typeof(GT.CS6460.BuddyUp.DomainModel.SecurityMaintenance));
            container.RegisterType(typeof(GT.CS6460.BuddyUp.DomainModel.IUser), typeof(GT.CS6460.BuddyUp.DomainModel.UserMaintenance));
            container.RegisterType(typeof(GT.CS6460.BuddyUp.DomainModel.ICourse), typeof(GT.CS6460.BuddyUp.DomainModel.CourseMaintenance));
            container.RegisterType(typeof(GT.CS6460.BuddyUp.DomainModel.IGroup), typeof(GT.CS6460.BuddyUp.DomainModel.GroupMaintenance));
            container.RegisterType(typeof(GT.CS6460.BuddyUp.DomainModel.IQuestionnaire), typeof(GT.CS6460.BuddyUp.DomainModel.QuestionnaireMaintenance));
            container.RegisterType(typeof(GT.CS6460.BuddyUp.DomainModel.IRole), typeof(GT.CS6460.BuddyUp.DomainModel.RoleMaintenance));
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}