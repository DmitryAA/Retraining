using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdVision.Retraining.DataLayer;
using EdVision.Retraining.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdVision.Retraining.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        readonly RetrainingContext context;

        public EmployeeController(RetrainingContext context) {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get() {
            return Ok(context.LoadEmpoyees());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id) {
            var employee = context.LoadEmpoyees().FirstOrDefault(e => e.Id == id);
            if (employee == null) {
                return NoContent();
            }
            return Ok(employee);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Employee value) {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value) {

        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
