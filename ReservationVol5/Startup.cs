using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReservationVol5.Startup))]
namespace ReservationVol5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
