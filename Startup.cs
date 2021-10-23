using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkillsShowcase.Startup))]
namespace SkillsShowcase
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
