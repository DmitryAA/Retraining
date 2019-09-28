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
        IPositionRecommendationDataProvider dataProvider;

        public EmployeeRecommendationController(IPositionRecommendationDataProvider dataProvider) {
            this.dataProvider = dataProvider;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeProfessionRecommendation>> Get(int id) {
            EmployeProfessionRecommendation employeeRecommendations = await dataProvider.Get(id);
            if (employeeRecommendations == null) {
                NoContent();
            }
            return Ok(employeeRecommendations);
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
