using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.OpenGenerics.Handlers
{
    public abstract class CommandHandlerBase<T, O> : ICommand<T>
        where T: class, IRequest
        where O: IResponse
    {
        public abstract O Handle(T input);

        public IResponse Handle(IRequest request)
        {
            return Handle(request as T);
        }
    }
}
