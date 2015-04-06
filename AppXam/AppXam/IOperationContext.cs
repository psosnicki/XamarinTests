using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public interface IOperationContext<T> 
    {
        T Context { get; set; }
        void RenewContext();
    }
}
