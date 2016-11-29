using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } 
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public override void Update(BaseEntity s)
        {
            if (!(s is Student))
                throw new ArgumentException("Parameter are not Student type");

            Student src = s as Student;
            this.FirstName = src.FirstName;
            this.SecondName = src.SecondName;
            this.Age = src.Age;
            this.Class = src.Class;
        }
    }
}
