using Blacklite.Framework.Metadata.Metadatums;
using Blacklite.Framework.Metadata.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
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
