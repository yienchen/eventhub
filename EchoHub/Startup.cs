using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(EchoHub.Startup))]

namespace EchoHub
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            RunSignalRCors(app);
        }

        private void RunSignalRDefault(IAppBuilder app)
        {
            app.MapSignalR();
        }

        private void RunSignalRCors(IAppBuilder app)
        {
            app.Map("/signalr", map => {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR();
            });           
        }
    }
}
