using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaxCalculator.Startup))]
namespace TaxCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
