using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using System;
using System.ComponentModel.DataAnnotations;
using Blacklite.Framework;
using Blacklite.Framework.Metadata;
using System.Linq;
using System.Reflection;
using Microsoft.Framework.DependencyInjection;

namespace Blacklite.UI.Metadatums.Resolvers
{
    [ServiceDescriptor(typeof(IApplicationTypeMetadatumResolver))]
    class DisplayTypeMetadatumResolver : SimpleTypeMetadatumResolver<Display>
    {
        public override Display Resolve(IMetadatumResolutionContext<ITypeMetadata> context)
        {
            var displayName = context.Metadata.TypeInfo
                .CustomAttributes.OfType<DisplayNameAttribute>()
                .SingleOrDefault()?.DisplayName ?? context.Metadata.Type.Name.AsUserFriendly();

            var shortName = context.Metadata.TypeInfo
                .CustomAttributes.OfType<ShortNameAttribute>()
                .SingleOrDefault()?.ShortName ?? displayName;

            var description = context.Metadata.TypeInfo
                .CustomAttributes.OfType<DescriptionAttribute>()
                .SingleOrDefault()?.Description;

            var displayOrder = context.Metadata.TypeInfo
                .CustomAttributes.OfType<OrderAttribute>()
                .SingleOrDefault()?.Order ?? 0;

            var groups = context.Metadata.TypeInfo.CustomAttributes
                .OfType<GroupAttribute>()
                .SelectMany(x => x.Groups)
                .ToArray();

            return new Display(displayName, description, groups, displayOrder, shortName);
        }
    }

    [ServiceDescriptor(typeof(IApplicationPropertyMetadatumResolver))]
    class DisplayPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Display>
    {
        private const int DisplayOrderDefault = 10000;

        public override Display Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var displayAttribute = context.Metadata.Attributes
                .OfType<DisplayAttribute>()
                .SingleOrDefault();
            if (displayAttribute != null)
            {
                return new Display(displayAttribute);
            }

            var displayName = context.Metadata.Attributes
                .OfType<DisplayNameAttribute>()
                .SingleOrDefault()?.DisplayName ?? context.Metadata.PropertyType.Name.AsUserFriendly();

            var shortName = context.Metadata.Attributes
                .OfType<ShortNameAttribute>()
                .SingleOrDefault()?.ShortName ?? displayName;

            var description = context.Metadata.Attributes
                .OfType<DescriptionAttribute>()
                .SingleOrDefault()?.Description;

            var displayOrder = context.Metadata.Attributes
                .OfType<OrderAttribute>()
                .SingleOrDefault()?.Order ?? GetRelativePosition(context.Metadata);

            var groups = context.Metadata.Attributes
                .OfType<GroupAttribute>()
                .SelectMany(x => x.Groups)
                .ToArray();

            return new Display(displayName, description, groups, displayOrder, shortName);
        }

        private static int CalculateDisplayOrder(PropertyInfo propertyInfo)
        {
            var delcaringTypeProperties = propertyInfo.DeclaringType.GetTypeInfo().DeclaredProperties;
            var propertiesOnDeclaringType = delcaringTypeProperties.Where(x => x.DeclaringType == propertyInfo.DeclaringType);
            var index = propertiesOnDeclaringType.Select((x, i) => x.Name == propertyInfo.Name ? i : -1).FirstOrDefault(x => x > -1);
            var numberOfPropertiesAboveDeclaringType = delcaringTypeProperties.Where(x => x.DeclaringType != propertyInfo.DeclaringType).Count();

            return index + 1 + numberOfPropertiesAboveDeclaringType;
        }

        public virtual int GetRelativePosition(IPropertyMetadata metadata)
        {
            var property = metadata.ParentMetadata.Type.GetTypeInfo().DeclaredProperties.SingleOrDefault(x => x.Name == metadata.Name);

            if (property != null)
                return CalculateDisplayOrder(property);

            return 0;
        }
    }
}
