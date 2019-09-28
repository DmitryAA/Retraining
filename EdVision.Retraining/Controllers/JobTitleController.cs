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
    public class JobTitleController : ControllerBase {
        readonly RetrainingContext context;

        public JobTitleController(RetrainingContext context) {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<JobTitle>> Get() {
            return Ok(context.LoadPositions());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<JobTitle> Get(int id) {
            var jobTitle = context.LoadPositions().FirstOrDefault(e => e.Id == id);
            if (jobTitle == null) {
                return NoContent();
            }
            return Ok(jobTitle);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] JobTitle value) {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JobTitle value) {

        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
