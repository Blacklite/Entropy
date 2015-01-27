using Blacklite.Framework.Metadata.Metadatums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
    public class Required : IMetadatum
    {
        public Required(bool required)
        {
            IsRequired = required;
        }

        public Required(RequiredAttribute attribute) : this(true) { }

        public bool IsRequired { get; }
    }
}
