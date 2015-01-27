using Blacklite.Framework.Metadata.Metadatums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UploadAttribute : DataTypeAttribute
    {
        public UploadAttribute() : base(DataType.Upload) { }
    }

    public class Upload : InfoType
    {
        public Upload() : base(DataType.Upload) { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PostalCodeAttribute : DataTypeAttribute
    {
        public PostalCodeAttribute() : base(DataType.PostalCode) { }
    }

    public class PostalCode : InfoType
    {
        public PostalCode() : base(DataType.PostalCode) { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ImageAttribute : DataTypeAttribute
    {
        public ImageAttribute() : base(DataType.ImageUrl) { }
    }

    public class Image : InfoType
    {
        public Image() : base(DataType.ImageUrl) { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UrlAttribute : DataTypeAttribute
    {
        public UrlAttribute() : base(DataType.Url) { }
    }

    public class Url : InfoType
    {
        public Url() : base(DataType.Url) { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CurrencyAttribute : DataTypeAttribute
    {
        public CurrencyAttribute() : base(DataType.Currency) { }
    }

    public class Currency : InfoType
    {
        public Currency() : base(DataType.Currency) { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PhoneNumberAttribute : DataTypeAttribute
    {
        public PhoneNumberAttribute() : base(DataType.PhoneNumber) { }
    }

    public class PhoneNumber : InfoType
    {
        public PhoneNumber() : base(DataType.PhoneNumber) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PasswordAttribute : DataTypeAttribute
    {
        public PasswordAttribute() : base(DataType.Password) { }
    }

    public class Password : InfoType
    {
        public Password() : base(DataType.Password) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EmailAttribute : DataTypeAttribute
    {
        public EmailAttribute() : base(DataType.EmailAddress) { }
    }

    public class Email : InfoType
    {
        public Email() : base(DataType.EmailAddress) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MultilineTextAttribute : DataTypeAttribute
    {
        public MultilineTextAttribute() : base(DataType.MultilineText) { }
    }

    public class MultilineText : InfoType
    {
        public MultilineText() : base(DataType.MultilineText) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class HtmlAttribute : DataTypeAttribute
    {
        public HtmlAttribute() : base(DataType.Html) { }
    }

    public class Html : InfoType
    {
        public Html() : base(DataType.Html) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TextAttribute : DataTypeAttribute
    {
        public TextAttribute() : base(DataType.Text) { }
    }

    public class Text : InfoType
    {
        public Text() : base(DataType.Text) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DateTimeAttribute : DataTypeAttribute
    {
        public DateTimeAttribute() : base(DataType.DateTime) { }
    }

    public class DateTime : InfoType
    {
        public DateTime() : base(DataType.DateTime) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TimeAttribute : DataTypeAttribute
    {
        public TimeAttribute() : base(DataType.Time) { }
    }

    public class Time : InfoType
    {
        public Time() : base(DataType.Time) { }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DateAttribute : DataTypeAttribute
    {
        public DateAttribute() : base(DataType.Date) { }
    }

    public class Date : InfoType
    {
        public Date() : base(DataType.Date) { }
    }

    public class InfoType : IMetadatum
    {
        public InfoType(DataType dataType)
        {
            DataType = dataType;
        }

        public DataType DataType { get; }
    }
}
