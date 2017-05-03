using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyecto.Startup))]
namespace proyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
