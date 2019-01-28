using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemRezerwacji.Startup))]
namespace SystemRezerwacji
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
