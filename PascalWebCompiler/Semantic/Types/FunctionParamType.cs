using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalWebCompiler.Semantic.Types
{
    public class FunctionParamType
    {
        public BaseType Type { get; set; }
        public bool ByReference { get; set; }

    }
}
