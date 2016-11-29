using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class StudentController
    {
        private IStudentRepository studentRepository;
        public StudentController()
        {
            this.studentRepository = new StudentRepository(new SchoolContext());
        }
        public void DoAction()
        {
            // Description for Repository pattern : http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
            Student newStudent = new Student();
            newStudent.FirstName = "Mikole"; newStudent.SecondName = "Shoe"; newStudent.Age = 23; newStudent.Class = "9-a";
            studentRepository.InsertStudent(newStudent);

            studentRepository.Save();

            var students = from s in studentRepository.GetStudents()
                           select s;

            students = students.OrderByDescending(s => s.Age);
            foreach(Student st in students)
            {
                Console.WriteLine(string.Format(" -- {0} {1} Age [{2}], class {3}", st.FirstName, st.SecondName, st.Age, st.Class));
            }
            Console.WriteLine("Dispose student Repository.");
            studentRepository.Dispose();

            Console.WriteLine("Pring Cources");

            UnitOfWork unitOfWork = new UnitOfWork();

            foreach (Course crs in unitOfWork.CourseRepository.Get()){
                Console.WriteLine(string.Format("ID- [{0}], Name - {1}", crs.ID, crs.Name));
            }

            Course c1 = new Course() { Name = "OOP"};
            unitOfWork.CourseRepository.Insert(c1);
            unitOfWork.Save();

            foreach (Course crs in unitOfWork.CourseRepository.Get())
            {
                Console.WriteLine(string.Format("ID- [{0}], Name - {1}", crs.ID, crs.Name));
            }
        }
    }
}
