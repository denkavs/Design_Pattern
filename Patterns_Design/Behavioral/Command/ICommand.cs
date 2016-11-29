using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Command
{
    //public interface ICommand
    //{
    //    void Execute();
    //}

    public interface ICommand<T>
    {
        void Execute(T param);
    }
}
