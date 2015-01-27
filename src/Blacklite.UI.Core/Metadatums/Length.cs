using Blacklite.Framework.Metadata.Metadatums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthAttribute : Attribute
    {
        public LengthAttribute(int min, int? max = null)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int? Max { get; }
    }

    public class Length : IMetadatum
    {
        public Length(int min, int? max = null)
        {
            Min = min;
            Max = max;
        }

        public Length(MaxLengthAttribute maxAttribute) : this(0, maxAttribute.Length) { }

        public Length(MinLengthAttribute minAttribute) : this(minAttribute.Length) { }

        public int Min { get; }
        public int? Max { get; }
    }
}
