﻿using Blacklite.Framework.Metadata;
using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using Microsoft.Framework.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blacklite.UI.Metadatums
{
    [ServiceDescriptor(typeof(IApplicationPropertyMetadatumResolver))]
    class RegularExpressionPropertyMetadatumResolver : SimplePropertyMetadatumResolver<RegularExpression>
    {
        public override RegularExpression Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var regularExpressionAttribute = context.Metadata.Attributes
                .OfType<RegularExpressionAttribute>()
                .SingleOrDefault();

            if (regularExpressionAttribute != null)
                return new RegularExpression(regularExpressionAttribute.Pattern);

            return null;
        }
    }
}
