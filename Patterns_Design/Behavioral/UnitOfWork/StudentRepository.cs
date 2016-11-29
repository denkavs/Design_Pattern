using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public Student GetStudentByID(int id)
        {
            return context.Students.Find(s=>s.ID == id);
        }

        public void InsertStudent(Student student)
        {
            student.ID = context.Students.Count + 1;
            context.Students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            Student student = context.Students.Find(s => s.ID == id);
            context.Students.Remove(student);
        }

        public void UpdateStudent(Student src)
        {
            Student dest = context.Students.Find(s => s.ID == src.ID);
            if(dest != null)
            {
                dest.FirstName = src.FirstName;
                dest.SecondName = src.SecondName;
                dest.Age = src.Age;
                dest.Class = src.Class;
            }
            //context.Entry(src).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
