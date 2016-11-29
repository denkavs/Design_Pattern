using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class SchoolContext
    {
        public SchoolContext()
        {
            this.Students.Add(new Student() { ID=1, FirstName="Vasya", SecondName="Pupkin", Age=20, Class="8-a" });
            this.Students.Add(new Student() { ID = 2, FirstName = "Gena", SecondName = "Lopata", Age = 21, Class = "8-a" });
            this.Students.Add(new Student() { ID = 3, FirstName = "Ivan", SecondName = "Ivanov", Age = 19, Class = "8-b" });
            this.Students.Add(new Student() { ID = 4, FirstName = "Olya", SecondName = "Hol", Age = 20, Class = "8-b" });
            this.Courses.Add(new Course() { ID = 1, Name="Math" });
            this.Courses.Add(new Course() { ID = 2, Name = "Lit" });
            this.Courses.Add(new Course() { ID = 3, Name = "Lang" });
        }

        public List<BaseEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            if (typeof(TEntity).Name == "Student")
                return this.Students.ToList<BaseEntity>();

            if (typeof(TEntity).Name == "Course")
                return this.Courses.ToList<BaseEntity>();

            return null;
            //return (DbSet<TEntity>)Activator.CreateInstance(typeof(DbSet<TEntity>));
        }

        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public void SaveChanges()
        { 
            // save db context - CommitChanges
        }
        public void Dispose() { }
    }
}
