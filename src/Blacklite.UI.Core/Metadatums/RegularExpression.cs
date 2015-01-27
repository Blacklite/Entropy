using Blacklite.Framework.Metadata.Metadatums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
    public class RegularExpression : IMetadatum
    {
        public RegularExpression(string pattern)
        {
            Pattern = pattern;
        }

        public RegularExpression(RegularExpressionAttribute attribute) : this(attribute.Pattern) { }

        public string Pattern { get; }
    }
}
