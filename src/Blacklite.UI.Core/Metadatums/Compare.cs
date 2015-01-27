using Blacklite.Framework.Metadata.Metadatums;
using System;

namespace Blacklite.UI.Metadatums
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CompareWithAttribute : Attribute
    {
        public string Property { get; }
        public CompareOperator Operator { get; }

        public CompareWithAttribute(string property, CompareOperator compareOperator = CompareOperator.EqualTo)
        {
            Property = property;
            Operator = compareOperator;
        }
    }

    public enum CompareOperator
    {
        EqualTo,
        NotEqualTo,
        GreaterThen,
        GreaterThenOrEqualTo,
        LessThen,
        LessThenOrEqualTo,
    }

    public class Compare : IMetadatum
    {
        public string Property { get; }
        public CompareOperator Operator { get; }

        public Compare(string property, CompareOperator compareOperator = CompareOperator.EqualTo)
        {
            Property = property;
            Operator = compareOperator;
        }

        public Compare(CompareWithAttribute attribute)
        {
            Property = attribute.Property;
            Operator = attribute.Operator;
        }
    }
}
