using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Semantic
{
    public class TypesTable
    {
        private readonly Dictionary<string, BaseType> _table;
        private static TypesTable _instance;

        private TypesTable()
        {
            _table = new Dictionary<string, BaseType>
            {
                {"integer", new IntegerType()},
                {"char", new CharType()},
                {"string", new StringType()},
                {"real", new RealType()},
                {"boolean", new BooleanType()},
                {"array", new ArrayType()},
                {"enum", new EnumType()},
                {"record", new RecordType()},
//                {"function", new FunctionType()}
            };
            //_table.Add("typedef", new TypeDefType());
        }

        public static TypesTable Instance => _instance ?? (_instance = new TypesTable());

        public void RegisterType(string name, BaseType baseType)
        {
            if (_table.ContainsKey(name))
            {
                throw new SemanticException($"Type: {name} exists.");
            }

            _table.Add(name, baseType);
        }

        public BaseType GetType(string name)
        {
            if (_table.ContainsKey(name))
            {
                return _table[name];
            }

            throw new SemanticException($"Type: {name} doesn't exists.");
        }


        public bool Contains(string name)
        {
            return _table.ContainsKey(name);
        }
    }
}
