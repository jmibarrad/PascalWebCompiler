using System.Collections.Generic;
using System.Linq;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.DeclareType;

namespace PascalWebCompiler.Semantic
{
    public class SymbolTable
    {
        private readonly Dictionary<string, BaseType> _table;
        private readonly List<string> _constants;
        private static SymbolTable _instance;
        private static readonly List<SymbolTable> SymbolTables = new List<SymbolTable>();


        private SymbolTable()
        {
            _table = new Dictionary<string, BaseType>();
            _constants = new List<string>();
        }

        //public static SymbolTable Instance => _instance != null ? SymbolTables.Last() : (SymbolTables.Insert(0, new SymbolTable()));
        public static SymbolTable Instance => _instance ?? (_instance = new SymbolTable());

        public void DeclareVariable(string name, string typeName)
        {
            if (_table.ContainsKey(name)) throw new SemanticException($"Variable: {name} exists.");
            if (TypesTable.Instance.Contains(name)) throw new SemanticException($"{name} is a Type.");

            _table.Add(name, TypesTable.Instance.GetType(typeName));
        }

        public void DeclareVariable(string name, BaseType type)
        {
            if (_table.ContainsKey(name)) throw new SemanticException($"Variable: {name} exists.");
            if (TypesTable.Instance.Contains(name)) throw new SemanticException($"{name} is a Type.");

            _table.Add(name, type);
        }

        public BaseType GetVariable(string name)
        {
            if (_table.ContainsKey(name))
            {
                return _table[name];
            }

            throw new SemanticException($"Variable: {name} doesn't exists.");
        }

        public void DeclareVariable(string value, string typeName, List<Range> ranges)
        {
           
            var type = TypesTable.Instance.GetType(typeName);
            //ranges.Reverse(0, ranges.Count);
            foreach (var range in ranges)
            {
                if(range.InferiorLimit.Value > range.SuperiorLimit.Value) throw new SemanticException("Invalid range: inferior limit is bigger than superior limit.");
                type = new ArrayType {InferiorLimit = range.InferiorLimit.Value, SuperiorLimit = range.SuperiorLimit.Value, Type = type};
            }

            if (_table.ContainsKey(value) || _constants.Contains(value)) throw new SemanticException($"Variable: {value} already exists.");
            if (TypesTable.Instance.Contains(value)) throw new SemanticException($"{value} it's a type.");

            _table.Add(value, type);
            
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
}

