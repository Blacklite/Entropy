﻿using Blacklite.Framework.Metadata;
using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Metadatums.Resolvers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blacklite.UI.Metadatums.Resolvers
{
    class UploadPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Upload>
    {
        public override Upload Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<UploadAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Upload();
            }

            var infoType = context.Metadata.Get<InfoType>()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Upload)
            {
                return new Upload();
            }

            return null;
        }
    }

    class PostalCodePropertyMetadatumResolver : SimplePropertyMetadatumResolver<PostalCode>
    {
        public override PostalCode Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<PostalCodeAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new PostalCode();
            }

            var infoType = context.Metadata.Get<InfoType>()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.PostalCode)
            {
                return new PostalCode();
            }

            return null;
        }
    }

    class ImagePropertyMetadatumResolver : SimplePropertyMetadatumResolver<Image>
    {
        public override Image Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<ImageAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Image();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.ImageUrl)
            {
                return new Image();
            }

            return null;
        }
    }

    class UrlPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Url>
    {
        public override Url Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<UrlAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Url();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Url)
            {
                return new Url();
            }

            return null;
        }
    }

    class CurrencyPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Currency>
    {
        public override Currency Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<CurrencyAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Currency();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Currency)
            {
                return new Currency();
            }

            return null;
        }
    }

    class PhoneNumberPropertyMetadatumResolver : SimplePropertyMetadatumResolver<PhoneNumber>
    {
        public override PhoneNumber Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<PhoneNumberAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new PhoneNumber();
            }

            var phoneAttribute = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<PhoneAttribute>().SingleOrDefault();
            if (phoneAttribute != null)
            {
                return new PhoneNumber();
            }

            var infoType = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<DataTypeAttribute>()
                    .SingleOrDefault()?.DataType;

            if (infoType.HasValue && infoType.Value == DataType.PhoneNumber)
            {
                return new PhoneNumber();
            }

            return null;
        }
    }

    class PasswordPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Password>
    {
        public override Password Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<PasswordAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Password();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Password)
            {
                return new Password();
            }

            return null;
        }
    }

    class EmailPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Email>
    {
        public override Email Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<EmailAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Email();
            }

            var emailAddressAttribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<EmailAddressAttribute>()
                    .SingleOrDefault();

            if (emailAddressAttribute != null)
            {
                return new Email();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.EmailAddress)
            {
                return new Email();
            }

            return null;
        }
    }

    class MultilineTextPropertyMetadatumResolver : SimplePropertyMetadatumResolver<MultilineText>
    {
        public override MultilineText Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<MultilineTextAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new MultilineText();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.MultilineText)
            {
                return new MultilineText();
            }

            return null;
        }
    }

    class HtmlPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Html>
    {
        public override Html Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<HtmlAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Html();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Html)
            {
                return new Html();
            }

            return null;
        }
    }

    class TextPropertyMetadatumResolver : SimplePropertyMetadatumResolver<Text>
    {
        public override Text Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<TextAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Text();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Text)
            {
                return new Text();
            }

            return null;
        }
    }

    class DateTimePropertyMetadatumResolver : SimplePropertyMetadatumResolver<DateTime>
    {
        public override DateTime Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<DateTimeAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new DateTime();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.DateTime)
            {
                return new DateTime();
            }

            return null;
        }
    }

    class TimePropertyMetadatumResolver : SimplePropertyMetadatumResolver<Time>
    {
        public override Time Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<TimeAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Time();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Time)
            {
                return new Time();
            }

            return null;
        }
    }

    class DatePropertyMetadatumResolver : SimplePropertyMetadatumResolver<Date>
    {
        public override Date Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var attribute = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<DateAttribute>()
                    .SingleOrDefault();

            if (attribute != null)
            {
                return new Date();
            }

            var infoType = context.Metadata.PropertyTypeInfo.CustomAttributes.OfType<DataTypeAttribute>().SingleOrDefault()?.DataType;
            if (infoType.HasValue && infoType.Value == DataType.Date)
            {
                return new Date();
            }

            return null;
        }
    }

    class InfoTypePropertyMetadatumResolver : SimplePropertyMetadatumResolver<InfoType>
    {
        public override InfoType Resolve(IMetadatumResolutionContext<IPropertyMetadata> context)
        {
            var infoType = context.Metadata.PropertyTypeInfo
                    .CustomAttributes.OfType<DataTypeAttribute>()
                    .SingleOrDefault()?.DataType;

            if (infoType.HasValue)
            {
                return new InfoType(infoType.Value);
            }

            return null;
        }
    }
}
