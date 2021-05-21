using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.common
{

    public interface IContext
    {
        IDictionary<string, object> Result { get; }
        IList<string> Error { get; }
    }

    public interface IExpression
    {
        void Interpreter(IContext context);
    }


}
