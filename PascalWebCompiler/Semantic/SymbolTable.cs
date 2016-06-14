using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Semantic
{
    public class SymbolTable
    {
        private readonly Dictionary<string, BaseType> _table;
        private readonly List<string> _constants;
        private static SymbolTable _instance;


        private SymbolTable()
        {
            _table = new Dictionary<string, BaseType>();
            _constants = new List<string>();
        }

        public static SymbolTable Instance => _instance ?? (_instance = new SymbolTable());

        public void DeclareVariable(string name, string typeName)
        {
            if (_table.ContainsKey(name))
            {
                throw new SemanticException($"Variable  :{name} exists.");
            }

            if (TypesTable.Instance.Contains(name))
                throw new SemanticException($"  :{name} is a Type.");

            _table.Add(name, TypesTable.Instance.GetType(typeName));
        }

        public BaseType GetVariable(string name)
        {
            if (_table.ContainsKey(name))
            {
                return _table[name];
            }

            throw new SemanticException($"Variable :{name} doesn't exists.");
        }

        public void DeclareVariable(string value, string typeName, List<int> dimensions)
        {
            if (dimensions.Count == 0)
            {
                DeclareVariable(value, typeName);
            }
            else
            {
                var type = TypesTable.Instance.GetType(typeName);
                dimensions.Reverse(0, dimensions.Count);
                foreach (var dimension in dimensions)
                {

                    //type = new ArrayType(dimension, type);

                }
                if (_table.ContainsKey(value))
                {
                    throw new SemanticException($"Variable: {value} already exists.");
                }

                if (TypesTable.Instance.Contains(value))
                    throw new SemanticException($"{value} it's a type.");

                _table.Add(value, type);
            }
        }

        public void AddConstant(string value)
        {
            _constants.Add(value);
        }

        public bool GetConstant(string value)
        {
            return _constants.Contains(value);
        }
    }

    //public class ArrayType : BaseType
    //{
    //    public int Dimension { get; set; }
    //    public BaseType Type { get; set; }

    //    public ArrayType(int dimension, BaseType type)
    //    {
    //        Dimension = dimension;
    //        Type = type;
    //    }

    //    public override bool IsAssignable(BaseType otherType)
    //    {
    //        if (otherType is ArrayType)
    //        {
    //            var paramArray = (ArrayType)otherType;
    //            if (Dimension == paramArray.Dimension && Type.IsAssignable(paramArray.Type))
    //            {
    //                return true;
    //            }
    //        }

    //        return false;
    //    }
    //}
}

