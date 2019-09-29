using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EdVision.Retraining.API.Cashe;
using EdVision.Retraining.DataLayer;
using EdVision.Retraining.Model;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace EdVision.Retraining.API {
    public class RequestStringBuilder {
        public string GetEmployeeRecomendation(int employeeId) {
            return "";
        }
    }

    public interface IPositionRecommendationDataProvider {
        Task<EmployePositionRecommendation> Get(int employeeId);
    }

    public class PositionRecommendationDataProvider: IPositionRecommendationDataProvider {
        RequestStringBuilder requestStringBuilder;
        TemporaryCashe<int, EmployePositionRecommendation> cashe;
        RetrainingContext context;

        public PositionRecommendationDataProvider(TimeSpan casheActuality, RetrainingContext context) {
            this.requestStringBuilder = new RequestStringBuilder();
            this.cashe = new TemporaryCashe<int, EmployePositionRecommendation>(casheActuality);
            this.context = context;
        }

        public async Task<EmployePositionRecommendation> Get(int employeeId) {
            EmployePositionRecommendation vm = cashe[employeeId];
            if (vm != null) return vm;

            var courses = context.LoadCourses();
            var positions = context.LoadPositions();
            var employee = context.LoadEmpoyees().FirstOrDefault(e => e.Id == employeeId);
            if (employee == null) return null;

            List<RecommendationSystemAnswerItem> recommendationSystemAnswers = await Request<List<RecommendationSystemAnswerItem>>(requestStringBuilder.GetEmployeeRecomendation(employeeId));
            List<PositionRecommendation> positionRecommendations = recommendationSystemAnswers.Select(
                a => new PositionRecommendation(
                    positions.First(p => p.Id == a.PositionId),
                    courses.Where(c => a.CourseIds.Contains(c.Id))
                )
            ).ToList();
            var employePositionRecommendation = new EmployePositionRecommendation(employee, positionRecommendations);


            cashe[employeeId] = employePositionRecommendation;
            return employePositionRecommendation;
        }

        //private async Task<T> Request<T>(string requestString) {
        //using (var httpClient = new HttpClient()) {
        //    string json = await httpClient.GetStringAsync(requestString);
        //    return Deserialize<T>(json);
        //}
        //}

        private Task<List<RecommendationSystemAnswerItem>> Request<T>(string requestString) {
            return Task.FromResult(new List<RecommendationSystemAnswerItem> {
                new RecommendationSystemAnswerItem(1, new List<int> { 1, 2 }),
                new RecommendationSystemAnswerItem(2, new List<int> { 3, 4 })
            });
        }
        

        private T Deserialize<T>(string jsonString) {
            return JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }

    public static class PositionRecommendationDataProviderExtension {
        public static void AddPositionRecommendationDataProvider(this IServiceCollection services, TimeSpan actualityTime) {
            Func<IServiceProvider, object> factory = (provider) =>
                new PositionRecommendationDataProvider(actualityTime, provider.CreateScope().ServiceProvider.GetService<RetrainingContext>());
            services.Add(new ServiceDescriptor(typeof(IPositionRecommendationDataProvider), factory, ServiceLifetime.Singleton));
        }
    }
}
