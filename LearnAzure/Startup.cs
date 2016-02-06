using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnAzure.Startup))]
namespace LearnAzure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
