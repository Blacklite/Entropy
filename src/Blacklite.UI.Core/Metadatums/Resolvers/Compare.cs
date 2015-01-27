using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using System;
using Blacklite.Framework.Metadata;
using System.Linq;

namespace Blacklite.UI.Metadatums.Resolvers
{
    class CompareWithPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Compare>
    {
        public override Compare Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<CompareWithAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Compare(attribute);
            }

            return null;
        }
    }
}
