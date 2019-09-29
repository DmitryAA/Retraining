using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdVision.Retraining.API.Cashe;
using EdVision.Retraining.DataLayer;
using EdVision.Retraining.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdVision.Retraining.API{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRecommendationController : ControllerBase {
        //IPositionRecommendationDataProvider dataProvider;
        RetrainingContext context;

        public EmployeeRecommendationController(RetrainingContext context/*IPositionRecommendationDataProvider dataProvider*/) {
            //this.dataProvider = dataProvider;
            this.context = context;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployePositionRecommendation>> Get(int id) {
            context.JobTitleRecommendations.Load();
            var recommendation = context.JobTitleRecommendations
                .Where(r => r.Employee.Id == id)
                .OrderBy(r => r.TimeStamp)
                .LastOrDefault();
            if (recommendation == null) {
                return NoContent();
            }
            return Ok(recommendation);
        }


        [HttpPost]
        public ActionResult Post([FromBody] List<RecommendationSystemAnswerItem> items) {
            List<JobTitleRecommendation> result = new List<JobTitleRecommendation>();
            foreach (RecommendationSystemAnswerItem item in items) {
                result.Add(new JobTitleRecommendation(
                    context.Employees.Find(item.EmployeeId),
                    context.JobTitles.Find(item.PositionId),
                    context.Courses.Where(c => item.CourseIds.Contains(c.Id))));
            }
            context.AddRange(result);
            context.SaveChanges();
            return Ok();
        }
        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
