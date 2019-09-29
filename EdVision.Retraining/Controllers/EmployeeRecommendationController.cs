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
           //context.JobTitleRecommendations.Load();
            var recommendation = context.JobTitleRecommendations
                .Include(r => r.Employee)
                .Include(r => r._CourseToJobTitleRecommendationMappings).ThenInclude(m => m.Course)
                .Include(r => r.JobTitle)
                .Where(r => r.Employee.Id == id)
                .OrderByDescending(r => r.TimeStamp).ThenBy(r => r.Distance)
                .Take(5)
                .ToList();

            var employee = context.Employees
                .Include(e => e.CourseResults)
                    .ThenInclude(cr => cr.Course)
                .Include(e => e.JobHistory)
                    .ThenInclude(jh => jh.Title)
                .Include(e => e.Competencies)
                    .ThenInclude(e => e.Competency)
                .FirstOrDefault(e => e.Id == recommendation[0].Employee.Id);
            if (recommendation.Count == 0) {
                return NoContent();
            }
            var result = new EmployePositionRecommendation(employee, recommendation.Select(r => new PositionRecommendation(r.JobTitle, r.CoursesToLearn)));
            return Ok(result);
        }


        [HttpPost]
        public ActionResult Post([FromBody] List<RecommendationSystemAnswerItem> items) {
            List<JobTitleRecommendation> result = new List<JobTitleRecommendation>();
            foreach (RecommendationSystemAnswerItem item in items) {
                result.Add(new JobTitleRecommendation(
                    context.Employees.Find(item.EmployeeId),
                    context.JobTitles.Find(item.PositionId),
                    item.Distance,
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
