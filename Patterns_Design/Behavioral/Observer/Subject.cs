using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Observer
{
    public class Subject
    {

        List<Observer1>  observer1s = new List<Observer1>();
        public void Register(Observer1 o)
        {
            if (observer1s.Contains(o))
            {
                Console.WriteLine("Object already exists");
            }
            else
            {
                observer1s.Add(o);
            }
        }

        public void UnRegister(Observer1 o)
        {
            if (!observer1s.Contains(o))
            {
                Console.WriteLine("Object does not exists in list");
            }
            else
            {
                observer1s.Remove(o);
            }
        }

        public void NotifyObservers()
        {
            foreach (var observer1 in observer1s)
            {
                observer1.Notify();
            }
        }
    }

    public abstract class Observer1
    {
        public abstract void Notify();
    }
}
