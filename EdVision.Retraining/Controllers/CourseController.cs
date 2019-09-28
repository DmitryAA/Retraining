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
    public class CourseController : ControllerBase {
        readonly RetrainingContext context;

        public CourseController(RetrainingContext context) {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get() {
            return Ok(context.LoadCourses());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id) {
            var employee = context.LoadCourses().FirstOrDefault(e => e.Id == id);
            if (employee == null) {
                return NoContent();
            }
            return Ok(employee);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Course value) {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course value) {

        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
