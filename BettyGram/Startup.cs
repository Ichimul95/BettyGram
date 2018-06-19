using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BettyGram.Startup))]
namespace BettyGram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
