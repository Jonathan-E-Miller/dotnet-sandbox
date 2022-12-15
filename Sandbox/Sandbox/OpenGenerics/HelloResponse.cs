using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.OpenGenerics
{
    internal class HelloResponse : IResponse
    {
        public DateTime ResponseTime { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
