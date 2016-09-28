using System;
using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class ArrayNode : TypeDeclarationNode
    {
        public List<Range> Ranges;
        public string ArrayType;
        public string primitiveType = string.Empty;
        public override void ValidateNodeSemantic()
        {
            var type = TypesTable.Instance.GetType(ArrayType);
            string dimensions = string.Empty;
            string dimensionsEmpty = string.Empty;
            foreach (var range in Ranges)
            {
                if (range.InferiorLimit.Value > range.SuperiorLimit.Value) throw new SemanticException("Invalid range: inferior limit is bigger than superior limit.");
                type = new ArrayType {primitiveType = ArrayType,JavaType = TypeName, InferiorLimit = range.InferiorLimit.Value, SuperiorLimit = range.SuperiorLimit.Value, Type = type };
                dimensions = $"[{range.SuperiorLimit.Value - range.InferiorLimit.Value + 1}]" + dimensions;
                dimensionsEmpty += "[]";
            }
            SymbolTable.Instance.DeclareVariable(TypeName, "array");
            TypesTable.Instance.RegisterType(TypeName, type);
            TypesTable.Instance.ArrayTable.Add(TypeName, new Tuple<string, string>(dimensionsEmpty, dimensions));
        }

        public override string GenerateCode()
        {
            var arrType = TypesTable.Instance.GetType(ArrayType);

            //var arrayInitializeCode = string.Empty;
            var arrayInitializeCode = GetFullDimensions(TypeName,arrType);
            var arrayCode = $"{primitiveType}{arrayInitializeCode.Item1} _{TypeName}";

            //Ranges.Reverse();
            //foreach (var range in Ranges)
            //{
            //    arrayCode += "[]";
            //    arrayInitializeCode += $"[{range.SuperiorLimit.Value-range.InferiorLimit.Value+1}]";
            //}

            return $"{arrayCode} = new {primitiveType}{arrayInitializeCode.Item2};\n";
        }

        public override BaseType GetBaseType()
        {
            var type = TypesTable.Instance.GetType(ArrayType);
            foreach (var range in Ranges)
            {
                type = new ArrayType { InferiorLimit = range.InferiorLimit.Value, SuperiorLimit = range.SuperiorLimit.Value, Type = type };
            }
            return type;
        }

        private Tuple<string,string> GetFullDimensions(string typename, BaseType arrayType)
        {
            BaseType type = arrayType;
            var dimensionEmpty = TypesTable.Instance.ArrayTable[typename].Item2;
            var dimensions = TypesTable.Instance.ArrayTable[typename].Item1;
            var typeStr = typename;
            while (true)
            {

                if (!(type is ArrayType))
                {
                    primitiveType = type.ToJavaString();
                    return new Tuple<string, string>(dimensions, dimensionEmpty);
                }
                else if (type is ArrayType && ((ArrayType)type).JavaType != typeStr)
                {
                    var typo = (ArrayType) type;
                    dimensions += TypesTable.Instance.ArrayTable[typo.JavaType].Item1;
                    dimensionEmpty += TypesTable.Instance.ArrayTable[typo.JavaType].Item2;
                    type = typo.Type;
                    typeStr = typo.JavaType;
                }
                else
                {
                    type = ((ArrayType)type).Type;
                }
            }
        }
    }
}