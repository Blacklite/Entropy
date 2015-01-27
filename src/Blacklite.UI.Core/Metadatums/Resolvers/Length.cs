using Blacklite.Framework.Metadata;
using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blacklite.UI.Metadatums.Resolvers
{
    class LengthPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Length>
    {
        public override Length Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var lengthAttribute = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<LengthAttribute>()
                .SingleOrDefault();

            if (lengthAttribute != null)
                return new Length(lengthAttribute);

            var minLengthAttribute = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<MinLengthAttribute>()
                .SingleOrDefault();

            var maxLengthAttribute = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<MaxLengthAttribute>()
                .SingleOrDefault();

            if (minLengthAttribute != null && maxLengthAttribute != null)
                return new Length(minLengthAttribute, maxLengthAttribute);

            if (minLengthAttribute != null)
                return new Length(minLengthAttribute);

            if (maxLengthAttribute != null)
                return new Length(maxLengthAttribute);

            return null;
        }
    }
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

        public Length(LengthAttribute lengthAttribute) : this(lengthAttribute.Min, lengthAttribute.Max) { }

        public Length(MaxLengthAttribute maxAttribute) : this(0, maxAttribute?.Length) { }

        public Length(MinLengthAttribute minAttribute) : this(minAttribute.Length) { }

        public Length(MinLengthAttribute minAttribute, MaxLengthAttribute maxAttribute) : this(minAttribute.Length, maxAttribute?.Length) { }

        public int Min { get; }
        public int? Max { get; }
    }
}
