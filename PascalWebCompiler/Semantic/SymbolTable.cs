using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Semantic
{
    public class SymbolTable
    {
        private readonly Dictionary<string, BaseType> _table;
        private readonly List<string> _constants;
        public static readonly List<SymbolTable> SymbolTables = new List<SymbolTable>();

        public SymbolTable()
        {
            _table = new Dictionary<string, BaseType>();
            _constants = new List<string>();
        }

        public static SymbolTable Instance
        {
            get {
                if (SymbolTables.Count == 0)
                {
                    SymbolTables.Add(new SymbolTable());
                }
                
                return SymbolTables[0];
            }
        }

        public static void AddSymbolTable(SymbolTable symbolTable)
        {
            SymbolTables.Insert(0, symbolTable);
        }

        public static void RemoveSymbolTable()
        {
            SymbolTables.RemoveAt(0);
        }

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
            /*if (_table.ContainsKey(name))
            {
                return _table[name];
            }*/
            foreach (var symbolTable in SymbolTables)
            {
                if (symbolTable._table.ContainsKey(name))
                    return symbolTable._table[name];
            }

            throw new SemanticException($"Variable: {name} doesn't exists.");
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

