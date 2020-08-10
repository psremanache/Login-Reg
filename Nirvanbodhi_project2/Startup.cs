using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nirvanbodhi_project2.Startup))]
namespace Nirvanbodhi_project2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
