using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.ChainOfResponsibility
{
    public interface IRequest
    {
    }

    public class Request1:IRequest
    {
        public string Value { get; set; }
    }

    public class Request2 : IRequest
    {
        public string Value { get; set; }
    }
}
