namespace BGTouristGuide.Api.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    using Data;
    using Data.Repositories;

    public static class NinjectConfig
    {
        public static Action<IKernel> DependensiesRegistration = kernel =>
        {
            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<DbContext>().To<BGTouristGuideDbContext>().InRequestScope();
        };

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            DependensiesRegistration(kernel);

            //kernel.Bind(k => k
            //    .From(AssembliesConstants.ServicesAssemblyName)
            //    .SelectAllClasses()
            //    .BindDefaultInterface());
        }
    }
}