using Blacklite.Framework.Metadata.Metadatums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ReadOnlyAttribute : Attribute
    {
        public ReadOnlyAttribute(bool readOnly)
        {
            ReadOnly = readOnly;
        }

        public bool ReadOnly { get; }
    }

    public class ReadOnly : IMetadatum
    {
        public ReadOnly(bool readOnly)
        {
            IsReadOnly = readOnly;
        }

        public ReadOnly(ReadOnlyAttribute attribute) : this(attribute.ReadOnly) { }

        public ReadOnly(EditableAttribute attribute) : this(!attribute.AllowEdit) { }

        public bool IsReadOnly { get; }
    }
}
