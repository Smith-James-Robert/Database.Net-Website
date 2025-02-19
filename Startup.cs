using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JS2247A5.Startup))]

namespace JS2247A5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
