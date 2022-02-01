using Microsoft.AspNetCore.Mvc;
using GreetingService.API;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreetingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        public List<Greeting> myList { get; set; }

        public GreetingController()
        {
            myList = new List<Greeting>();
            var greeting0 = new Greeting();
            greeting0.Id = Guid.NewGuid();
            greeting0.Message = "This is message 0";
            var greeting1 = new Greeting();
            greeting1.Id = Guid.NewGuid();
            greeting1.Message = "This is message 1";

            myList.Add(greeting0);
            myList.Add(greeting1);

        }

        // GET: api/<GreetingController>
        [HttpGet]
        public IEnumerable<Greeting> Get()
        {
            return myList;
        }

        // GET api/<GreetingController>/5
        [HttpGet("{id}")]
        public Greeting Get(int id)
        {
            try
            {
                return myList[id];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Greeting();
        }

        // POST api/<GreetingController>
        [HttpPost]
        public void Post([FromBody] Greeting greeting)
        {
            Console.WriteLine(greeting.Message);
        }

        // PUT api/<GreetingController>/5
        [HttpPut]
        public void Put([FromBody] Greeting greeting)
        {
            Console.WriteLine(greeting.Message);
        }

        
    }
}
