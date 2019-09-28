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
        Task<EmployeProfessionRecommendation> Get(int employeeId);
    }

    public class PositionRecommendationDataProvider: IPositionRecommendationDataProvider {
        RequestStringBuilder requestStringBuilder;
        TemporaryCashe<int, EmployeProfessionRecommendation> cashe;
        RetrainingContext context;

        public PositionRecommendationDataProvider(TimeSpan casheActuality, RetrainingContext context) {
            this.requestStringBuilder = new RequestStringBuilder();
            this.cashe = new TemporaryCashe<int, EmployeProfessionRecommendation>(casheActuality);
            this.context = context;
        }

        public async Task<EmployeProfessionRecommendation> Get(int employeeId) {
            EmployeProfessionRecommendation vm = cashe[employeeId];
            if (vm != null) return vm;

            var recommendations = await Task.Run(() => {
            var courses = context.LoadCourses();
            var positions = context.LoadPositions();
            var employee = context.LoadEmpoyees().FirstOrDefault(e => e.Id == employeeId);
            if (employee == null) return null;

            return new EmployeProfessionRecommendation(
                employee,
                new List<PositionRecommendation> {
                    new PositionRecommendation(
                            context.JobTitles.Find(2),
                            new List<Course> {
                                courses.FirstOrDefault(c => c.Id == 1), courses.FirstOrDefault(c => c.Id == 2)
                            }),
                    new PositionRecommendation(
                            context.JobTitles.Find(3),
                            new List<Course> {
                                courses.FirstOrDefault(c => c.Id == 3), courses.FirstOrDefault(c => c.Id == 4)
                            })
                });
            });
            cashe[employeeId] = recommendations;
            return recommendations;
        }

        private async Task<T> Request<T>(string requestString) {
            using (var httpClient = new HttpClient()) {
                string json = await httpClient.GetStringAsync(requestString);
                return Deserialize<T>(json);
            }
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
