﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pointage.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceService : ControllerBase
    {
        // GET: api/<AttendanceService>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AttendanceService>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttendanceService>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AttendanceService>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttendanceService>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
