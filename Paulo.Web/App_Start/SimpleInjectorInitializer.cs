using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Paulo.Core;
using Paulo.Core.Repositories;
using Paulo.Core.Services;
using Paulo.Data.Context;
using Paulo.Impl;
using Paulo.Impl.Repositories;
using Paulo.Impl.Services;
using Paulo.Data.Identity.Config;
using Paulo.Data.Identity.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Paulo.Web.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static void Initializer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializerContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializerContainer(Container container)
        {
            // Identity
            container.Register<AppDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser, int>>(() => new CustomUserStore(new AppDbContext()), Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            // Repositórios
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            container.Register<IFilmeRepository, FilmeRepository>(Lifestyle.Scoped);
            container.Register<IGeneroRepository, GeneroRepository>(Lifestyle.Scoped);
            container.Register<ILocacaoRepository, LocacaoRepository>(Lifestyle.Scoped);

            // Serviços
            container.Register(typeof(IService<>), typeof(Service<>), Lifestyle.Scoped);
            container.Register<IFilmeService, FilmeService>(Lifestyle.Scoped);
            container.Register<IGeneroService, GeneroService>(Lifestyle.Scoped);
            container.Register<ILocacaoService, LocacaoService>(Lifestyle.Scoped);
            container.Register<ICpfService, CpfService>(Lifestyle.Scoped);

            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
                {
                    return new OwinContext().Authentication;
                }

                return HttpContext.Current.GetOwinContext().Authentication;
            }, Lifestyle.Scoped);
        }
    }
}