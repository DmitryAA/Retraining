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
            retrainingContext.SaveChanges();
            

            var employee1 = new Employee("A", "A", "A");
            var eCompetency1_1 = new EmployeeCompetency(competency1, 0.5);
            var eCompetency1_2 = new EmployeeCompetency(competency2, 0.75);
            employee1.Competencies.Add(eCompetency1_1);
            employee1.Competencies.Add(eCompetency1_2);
            retrainingContext.Add(employee1);
            retrainingContext.Add(eCompetency1_1);
            retrainingContext.Add(eCompetency1_2);
            retrainingContext.SaveChanges();

            var employee2 = new Employee("B", "B", "B");
            var eCompetency2_1 = new EmployeeCompetency(competency1, 0.75);
            var eCompetency2_2 = new EmployeeCompetency(competency3, 0.5);
            employee2.Competencies.Add(eCompetency2_1);
            employee2.Competencies.Add(eCompetency2_2);
            retrainingContext.Add(employee2);
            retrainingContext.Add(eCompetency2_1);
            retrainingContext.Add(eCompetency2_2);
            retrainingContext.SaveChanges();

            var employee3 = new Employee("C", "C", "C");
            var eCompetency3_1 = new EmployeeCompetency(competency2, 0.75);
            var eCompetency3_2 = new EmployeeCompetency(competency3, 0.25);
            employee3.Competencies.Add(eCompetency3_1);
            employee3.Competencies.Add(eCompetency3_2);
            retrainingContext.Add(employee3);
            retrainingContext.Add(eCompetency3_1);
            retrainingContext.Add(eCompetency3_2);
            retrainingContext.SaveChanges();

            var employee4 = new Employee("D", "D", "D");
            var eCompetency4_1 = new EmployeeCompetency(competency2, 1);
            var eCompetency4_2 = new EmployeeCompetency(competency4, 1);
            employee4.Competencies.Add(eCompetency4_1);
            employee4.Competencies.Add(eCompetency4_2);
            retrainingContext.Add(employee4);
            retrainingContext.Add(eCompetency4_1);
            retrainingContext.Add(eCompetency4_2);
            retrainingContext.SaveChanges();


            var jobTitle1 = new JobTitle("Job 1", direction1);
            var requiredCompetency1_1 = new JobTitleCompetency(competency1, 0.5, 1);
            var requiredCompetency1_2 = new JobTitleCompetency(competency2, 0.25, 1);
            jobTitle1.RequiredCompetency.Add(requiredCompetency1_1);
            jobTitle1.RequiredCompetency.Add(requiredCompetency1_2);
            retrainingContext.Add(jobTitle1);
            retrainingContext.Add(requiredCompetency1_1);
            retrainingContext.Add(requiredCompetency1_2);
            retrainingContext.SaveChanges();

            var jobTitle2 = new JobTitle("Job 2", direction1);
            var requiredCompetency2_1 = new JobTitleCompetency(competency2, 0.5, 1);
            var requiredCompetency2_2 = new JobTitleCompetency(competency4, 0, 1);
            jobTitle2.RequiredCompetency.Add(requiredCompetency2_1);
            jobTitle2.RequiredCompetency.Add(requiredCompetency2_2);
            retrainingContext.Add(jobTitle2);
            retrainingContext.Add(requiredCompetency2_1);
            retrainingContext.Add(requiredCompetency2_2);
            retrainingContext.SaveChanges();

            var jobTitle3 = new JobTitle("Job 3", direction1);
            var requiredCompetency3_1 = new JobTitleCompetency(competency2, 0.5, 1);
            var requiredCompetency3_2 = new JobTitleCompetency(competency4, 1, 1);
            jobTitle3.RequiredCompetency.Add(requiredCompetency3_1);
            jobTitle3.RequiredCompetency.Add(requiredCompetency3_2);
            retrainingContext.Add(jobTitle3);
            retrainingContext.Add(requiredCompetency3_1);
            retrainingContext.Add(requiredCompetency3_2);
            retrainingContext.SaveChanges();

            var jobTitle4 = new JobTitle("Job 4", direction1);
            var requiredCompetency4_1 = new JobTitleCompetency(competency2, 0.5, 1);
            var requiredCompetency4_2 = new JobTitleCompetency(competency4, 0, 1);
            jobTitle4.RequiredCompetency.Add(requiredCompetency4_1);
            jobTitle4.RequiredCompetency.Add(requiredCompetency4_2);
            retrainingContext.Add(jobTitle4);
            retrainingContext.Add(requiredCompetency4_1);
            retrainingContext.Add(requiredCompetency4_2);
            retrainingContext.SaveChanges();


            //var course1 = new Course("", direction1, 100.0);
            //var inCourseCompetency1 = new EmployeeCompetency(competency1, 0.25);
            //var outCourseCompetency1 = new EmployeeCompetency(competency1, 0.5);
            //course1.RequiredCompetencies.Add(inCourseCompetency1);
            //course1.OutputCompetencies.Add(outCourseCompetency1);
            ////retrainingContext.AddRange(inCourseCompetency1, outCourseCompetency1);
            //retrainingContext.Add(course1);
            //retrainingContext.SaveChanges();

            //var course2 = new Course("", direction2, 150.0);
            //var inCourseCompetency2 = new EmployeeCompetency(competency2, 0.25);
            //var outCourseCompetency2 = new EmployeeCompetency(competency2, 0.5);
            //course2.RequiredCompetencies.Add(inCourseCompetency2);
            //course2.OutputCompetencies.Add(outCourseCompetency2);
            //retrainingContext.Add(course2);
            //retrainingContext.AddRange(inCourseCompetency2, outCourseCompetency2);
            //retrainingContext.SaveChanges();


            //var course3 = new Course("", direction3, 100.0);
            //var inCourseCompetency3 = new EmployeeCompetency(competency3, 0.25);
            //var outCourseCompetency3 = new EmployeeCompetency(competency3, 0.5);
            //course3.RequiredCompetencies.Add(inCourseCompetency3);
            //course3.OutputCompetencies.Add(outCourseCompetency3);
            //retrainingContext.Add(course3);
            //retrainingContext.AddRange(inCourseCompetency3, outCourseCompetency3);
            //retrainingContext.SaveChanges();


            //var course4 = new Course("", direction4, 100.0);
            //var inCourseCompetency4 = new EmployeeCompetency(competency4, 0.25);
            //var outCourseCompetency4 = new EmployeeCompetency(competency4, 0.5);
            //course4.RequiredCompetencies.Add(inCourseCompetency4);
            //course4.OutputCompetencies.Add(outCourseCompetency4);
            //retrainingContext.AddRange(inCourseCompetency4, outCourseCompetency4);
            //retrainingContext.Add(course4);
            //retrainingContext.SaveChanges();
        }
    }
}
