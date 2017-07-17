using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EchoHub.Controllers
{
    public class EventHubController : ApiController
    {
        [HttpPost]
        [Route("echohub/hello")]
        public HttpResponseMessage SayHello([FromBody] string greeting)
        {
            var echoHub = GlobalHost.ConnectionManager.GetHubContext<EchoHub.EventHub.EchoHub>();
            var clients = echoHub.Clients.All;

            clients.greetings(greeting);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // GET: api/EventHub
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EventHub/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EventHub
        public void Post([FromBody]string greeting)
        {
            var echoHub = GlobalHost.ConnectionManager.GetHubContext<EchoHub.EventHub.EchoHub>();
            var clients = echoHub.Clients.All;
            
            clients.greetings(greeting);

            //return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/EventHub/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EventHub/5
        public void Delete(int id)
        {
        }
    }
}
