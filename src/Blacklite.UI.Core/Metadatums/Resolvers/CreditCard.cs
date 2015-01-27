using Blacklite.Framework.Metadata;
using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blacklite.UI.Metadatums.Resolvers
{
    class CreditCardPropertyMetadatumResolver : SimplePropertyMetadatumResolver<CreditCard>
    {
        public override CreditCard Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<CreditCardAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new CreditCard();
            }

            var infoType = context.Metadata.Get<InfoType>()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.CreditCard)
            {
                return new CreditCard();
            }

            return null;
        }
    }
}
