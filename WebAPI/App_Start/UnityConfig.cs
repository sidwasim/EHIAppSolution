using AutoMapper;
using Ehi.Services.Contact.Engines;
using Ehi.Services.Contact.Managers;
using Ehi.Services.ContactRA;
using Ehi.Services.Contract.External.ServiceContracts;
using Ehi.Services.Contract.Internal.ServiceContracts;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebAPI.App_Start;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterInstance<IMapper>(AutoMapperConfig.Mapper);
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IMapper, Mapper>();
            container.RegisterType<IContactManager, ContactManager>();
            container.RegisterType<IContactEngine, ContactEngine>();
            container.RegisterType<IContactRa, ContactRa>();
     
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}