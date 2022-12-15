using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.OpenGenerics
{
    internal class HelloRequest : IRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}
