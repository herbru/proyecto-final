using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyecto_final_asp.Startup))]
namespace proyecto_final_asp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
