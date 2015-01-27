using Blacklite.Framework.Metadata.Metadatums;
using System;

namespace Blacklite.UI.Metadatums
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CreditCardAttribute : Attribute
    {
    }

    public class CreditCard : IMetadatum
    {

    }
}
