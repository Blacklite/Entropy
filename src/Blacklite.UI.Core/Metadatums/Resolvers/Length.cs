using Blacklite.Framework.Metadata;
using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using Microsoft.Framework.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blacklite.UI.Metadatums.Resolvers
{
    [ServiceDescriptor(typeof(IApplicationPropertyMetadatumResolver))]
    class LengthPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Length>
    {
        public override Length Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var lengthAttribute = context.Metadata.Attributes
                .OfType<LengthAttribute>()
                .SingleOrDefault();

            if (lengthAttribute != null)
                return new Length(lengthAttribute);

            var minLengthAttribute = context.Metadata.Attributes
                .OfType<MinLengthAttribute>()
                .SingleOrDefault();

            var maxLengthAttribute = context.Metadata.Attributes
                .OfType<MaxLengthAttribute>()
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
}
