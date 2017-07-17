using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Diagnostics;

namespace EchoHub.EventHub
{
    [HubName("echo")]
    public class EchoHub : Hub
    {
        public EchoHub()
        {

        }

        public void Say(string message)
        {
            Trace.WriteLine(message);
        }

        public void Hello()
        {            
            var msg = string.Format("Greeting {0}, it's {1:F}", Context.ConnectionId, DateTime.Now);

            var all = Clients.Caller;
            all.greetings(msg);
        }
    }
}