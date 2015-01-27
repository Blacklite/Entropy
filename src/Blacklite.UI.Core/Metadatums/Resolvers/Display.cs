using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using System;
using System.ComponentModel.DataAnnotations;
using Blacklite.Framework;
using Blacklite.Framework.Metadata;
using System.Linq;
using System.Reflection;

namespace Blacklite.UI.Metadatums.Resolvers
{
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

    class DisplayPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Display>
    {
        private const int DisplayOrderDefault = 10000;

        public override Display Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var displayAttribute = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<DisplayAttribute>()
                .SingleOrDefault();
            if (displayAttribute != null)
            {
                return new Display(displayAttribute);
            }

            var displayName = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<DisplayNameAttribute>()
                .SingleOrDefault()?.DisplayName ?? context.Metadata.PropertyType.Name.AsUserFriendly();

            var shortName = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<ShortNameAttribute>()
                .SingleOrDefault()?.ShortName ?? displayName;

            var description = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<DescriptionAttribute>()
                .SingleOrDefault()?.Description;

            var displayOrder = context.Metadata.PropertyTypeInfo
                .CustomAttributes.OfType<OrderAttribute>()
                .SingleOrDefault()?.Order ?? GetRelativePosition(context.Metadata);

            var groups = context.Metadata.PropertyTypeInfo.CustomAttributes
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
