using System;
using System.Collections.Generic;
using EdVision.Retraining.Model;

namespace EdVision.Retraining.DataLayer {
    public static class DataSeeder {
        public static void Seed(RetrainingContext retrainingContext) {
            retrainingContext.Database.EnsureCreated();


            var competency1 = new Competency("Competency 1", CompetencyType.Range);
            var competency2 = new Competency("Competency 2", CompetencyType.Range);
            var competency3 = new Competency("Competency 3", CompetencyType.Range);
            var competency4 = new Competency("Competency 4", CompetencyType.Bool);
            var competency5 = new Competency("Competency 5", CompetencyType.Range);
            var competency6 = new Competency("Competency 6", CompetencyType.Range);
            retrainingContext.Competencies.AddRange(competency1, competency2, competency3, competency4, competency5, competency6);

            
            retrainingContext.Employees.Add(
                new Employee {
                    FirstName = "A",
                    MiddleName = "A",
                    LastName = "A",
                    Competencies = new List<EmployeeCompetency> {
                        new EmployeeCompetency(competency1, 0.5),
                        new EmployeeCompetency(competency2, 0.75)
                    }
                });
            retrainingContext.SaveChanges();
            retrainingContext.Employees.Add(
                new Employee {
                    FirstName = "B",
                    MiddleName = "B",
                    LastName = "B",
                    Competencies = new List<EmployeeCompetency> {
                        new EmployeeCompetency(competency1, 0.75),
                        new EmployeeCompetency(competency3, 0.5)
                    }
                });
            retrainingContext.SaveChanges();
            retrainingContext.Employees.Add(
                new Employee {
                    FirstName = "C",
                    MiddleName = "C",
                    LastName = "C",
                    Competencies = new List<EmployeeCompetency> {
                        new EmployeeCompetency(competency2, 0.75),
                        new EmployeeCompetency(competency3, 0.25)
                    }
                });
            retrainingContext.SaveChanges();
            retrainingContext.Employees.Add(
                new Employee {
                    FirstName = "D",
                    MiddleName = "D",
                    LastName = "D",
                    Competencies = new List<EmployeeCompetency> {
                        new EmployeeCompetency(competency2, 1),
                        new EmployeeCompetency(competency4, 1)
                    }
                });
            retrainingContext.SaveChanges();


            retrainingContext.JobTitles.Add(
                new JobTitle {
                    Name = "Job 1",
                    RequiredCompetency = new List<JobTitleCompetency> {
                        new JobTitleCompetency(competency1, 0.5, 1),
                        new JobTitleCompetency(competency2, 0.25, 1)
                    }
                });
            retrainingContext.SaveChanges();
            retrainingContext.JobTitles.Add(
                new JobTitle {
                    Name = "Job 2",
                    RequiredCompetency = new List<JobTitleCompetency> {
                        new JobTitleCompetency(competency2, 0.25, 1),
                        new JobTitleCompetency(competency4, 0, 1)
                    }
                });
            retrainingContext.SaveChanges();
            retrainingContext.JobTitles.Add(
                new JobTitle {
                    Name = "Job 3",
                    RequiredCompetency = new List<JobTitleCompetency> {
                        new JobTitleCompetency(competency3, 0.75, 1),
                        new JobTitleCompetency(competency4, 1, 1)
                    }
                });
            retrainingContext.SaveChanges();
            retrainingContext.JobTitles.Add(
                new JobTitle {
                    Name = "Job 4",
                    RequiredCompetency = new List<JobTitleCompetency> {
                        new JobTitleCompetency(competency1, 1, 1),
                        new JobTitleCompetency(competency4, 0, 1)
                    }
                });
            retrainingContext.SaveChanges();
        }
    }
}
