﻿using Microsoft.AspNetCore.Mvc;
using GreetingService.Core.Entities;
using GreetingService.Infrastructure;
using GreetingService.API.Authentication;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreetingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuth]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingRepository _greetingRepository;

        public GreetingController(IGreetingRepository greetingRepository)
        {
            _greetingRepository = greetingRepository;
        }

        // GET: api/<GreetingController>
        [HttpGet]
        
        public IEnumerable<Greeting> Get()
        {
            return _greetingRepository.Get();
        }

        // GET api/<GreetingController>/5
        [HttpGet("{id}")]
        public Greeting Get(Guid id)
        {
            try
            {
                return _greetingRepository.Get(id);
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
            _greetingRepository.Create(greeting);
            Console.WriteLine(greeting.Message);
        }

        // PUT api/<GreetingController>/5
        [HttpPut]
        public void Put([FromBody] Greeting greeting)
        {
            _greetingRepository.Update(greeting);
            Console.WriteLine(greeting.Message);
        }

        
    }
}
