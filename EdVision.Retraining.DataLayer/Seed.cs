using System;
using System.Collections.Generic;
using EdVision.Retraining.Model;

namespace EdVision.Retraining.DataLayer {
    public static class DataSeeder {
        public static void Seed(RetrainingContext retrainingContext) {
            retrainingContext.Database.EnsureCreated();

            var direction1 = new Direction("Direction 1");
            var direction2 = new Direction("Direction 2");
            var direction3 = new Direction("Direction 3");
            var direction4 = new Direction("Direction 4");
            var direction5 = new Direction("Direction 5");
            var direction6 = new Direction("Direction 6");
            retrainingContext.Directions.AddRange(direction1, direction2, direction3, direction4, direction5, direction6);


            var competency1 = new Competency("Competency 1", CompetencyType.Range);
            var competency2 = new Competency("Competency 2", CompetencyType.Range);
            var competency3 = new Competency("Competency 3", CompetencyType.Range);
            var competency4 = new Competency("Competency 4", CompetencyType.Bool);
            var competency5 = new Competency("Competency 5", CompetencyType.Range);
            var competency6 = new Competency("Competency 6", CompetencyType.Range);
            retrainingContext.Competencies.AddRange(competency1, competency2, competency3, competency4, competency5, competency6);


            var baseJob = new JobTitle("Base Job", direction3);
            baseJob.RequiredCompetency.Add(new JobTitleCompetency(competency2, 0.5, 1));
            baseJob.RequiredCompetency.Add(new JobTitleCompetency(competency4, 1, 1));
            retrainingContext.Add(baseJob);

            var jobTitle1 = new JobTitle("Job 1", direction1);
            jobTitle1.RequiredCompetency.Add(new JobTitleCompetency(competency1, 0.5, 1));
            jobTitle1.RequiredCompetency.Add(new JobTitleCompetency(competency2, 0.25, 1));
            retrainingContext.Add(jobTitle1);

            var jobTitle2 = new JobTitle("Job 2", direction1);
            jobTitle2.RequiredCompetency.Add(new JobTitleCompetency(competency2, 0.5, 1));
            jobTitle2.RequiredCompetency.Add(new JobTitleCompetency(competency4, 0, 1));
            retrainingContext.Add(jobTitle2);

            var jobTitle3 = new JobTitle("Job 3", direction1);
            jobTitle3.RequiredCompetency.Add(new JobTitleCompetency(competency2, 0.5, 1));
            jobTitle3.RequiredCompetency.Add(new JobTitleCompetency(competency4, 1, 1));
            retrainingContext.Add(jobTitle3);

            var jobTitle4 = new JobTitle("Job 4", direction1);
            jobTitle4.RequiredCompetency.Add(new JobTitleCompetency(competency2, 0.5, 1));
            jobTitle4.RequiredCompetency.Add(new JobTitleCompetency(competency4, 0, 1));
            retrainingContext.Add(jobTitle4);
            

            var course1 = new Course("Course 1", direction1, 100.0);
            course1.RequiredCompetencies.Add(new CourseInCompetency(competency1, 0.25));
            course1.OutputCompetencies.Add(new CourseOutCompetency(competency1, 0.5));
            retrainingContext.Add(course1);

            var course2 = new Course("Course 2", direction2, 150.0);
            course2.RequiredCompetencies.Add(new CourseInCompetency(competency2, 0.25));
            course2.OutputCompetencies.Add(new CourseOutCompetency(competency2, 0.5));
            retrainingContext.Add(course2);

            var course3 = new Course("Course 3", direction3, 100.0);
            course3.RequiredCompetencies.Add(new CourseInCompetency(competency3, 0.25));
            course3.OutputCompetencies.Add(new CourseOutCompetency(competency3, 0.5));
            retrainingContext.Add(course3);

            var course4 = new Course("Course 4", direction1, 100.0);
            course4.RequiredCompetencies.Add(new CourseInCompetency(competency1, 0));
            course4.OutputCompetencies.Add(new CourseOutCompetency(competency1, 0.25));
            retrainingContext.Add(course4);
            

            var employee1 = new Employee("A", "A", "A", new DateTime(1970, 1, 1), 0.2, 0.9);
            employee1.Competencies.Add(new EmployeeCompetency(competency1, 0.5));
            employee1.Competencies.Add(new EmployeeCompetency(competency2, 0.75));
            employee1.JobHistory.Add(new JobHistoryItem(baseJob, new DateTime(1990, 1, 1)));
            retrainingContext.Add(employee1);

            var employee2 = new Employee("B", "B", "B", new DateTime(1970, 1, 1), 0.25, 0.7);
            employee2.Competencies.Add(new EmployeeCompetency(competency1, 0.75));
            employee2.Competencies.Add(new EmployeeCompetency(competency3, 0.5));
            employee1.JobHistory.Add(new JobHistoryItem(baseJob, new DateTime(1990, 1, 1)));
            retrainingContext.Add(employee2);

            var employee3 = new Employee("C", "C", "C", new DateTime(1970, 1, 1), 0.8, 0.8);
            employee3.Competencies.Add(new EmployeeCompetency(competency2, 0.75));
            employee3.Competencies.Add(new EmployeeCompetency(competency3, 0.25));
            employee1.JobHistory.Add(new JobHistoryItem(baseJob, new DateTime(1990, 1, 1)));
            retrainingContext.Add(employee3);

            var employee4 = new Employee("D", "D", "D", new DateTime(1970, 1, 1), 0.2, 0.2);
            employee4.Competencies.Add(new EmployeeCompetency(competency2, 1));
            employee4.Competencies.Add(new EmployeeCompetency(competency4, 1));
            employee1.JobHistory.Add(new JobHistoryItem(baseJob, new DateTime(1990, 1, 1)));
            retrainingContext.Add(employee4);


            retrainingContext.SaveChanges();
        }
    }
}
