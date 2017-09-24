using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using GreetingsWebAPI.Models;

namespace GreetingsWebAPI.Controllers
{
    public class GreetingsController : ApiController
    {
        List<Greeting> greetings = new List<Greeting>();

        public GreetingsController() {
            greetings.Add(new Greeting { Id = 0, Message = "Hello World!" });
            greetings.Add(new Greeting { Id = 1, Message = "Hello Arnold!" });
        }

        public GreetingsController(List<Greeting> greetings)
        {
            this.greetings = greetings;
        }

        public IEnumerable<Greeting> GetAllGreetings()
        {
            return greetings;
        }

        public IHttpActionResult GetGreeting(int id)
        {
            var greeting = greetings.FirstOrDefault<Greeting>(x => x.Id == id);
            if (greeting == null)
                return NotFound();
            else
                return Ok(greeting);
        }
        
    }
}
