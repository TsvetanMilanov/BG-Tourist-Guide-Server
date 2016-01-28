using System.Web.Http;

using Microsoft.Owin;
using Owin;

using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using BGTouristGuide.Api.App_Start;

[assembly: OwinStartup(typeof(BGTouristGuide.Api.Startup))]

namespace BGTouristGuide.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.Initialize();
            DatabaseConfig.Initialize();

            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
