using Blacklite.Framework.Metadata.Metadatums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blacklite.UI.Metadatums
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface)]
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class GroupAttribute : Attribute
    {
        public GroupAttribute(params string[] groups)
        {
            Groups = groups;
        }

        public string[] Groups { get; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface)]
    public class OrderAttribute : Attribute
    {
        public OrderAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface)]
    public class ShortNameAttribute : Attribute
    {
        public ShortNameAttribute(string displayName)
        {
            ShortName = displayName;
        }

        public string ShortName { get; }
    }

    public class Display : IMetadatum
    {
        public string Name { get; }
        public string Description { get; }
        public string[] Groups { get; }
        public int Order { get; }
        public string ShortName { get; }

        public Display(string name, string description, string[] groups, int displayOrder, string shortName)
        {
            Name = name;
            Description = description;
            Groups = groups;
            Order = displayOrder;
            ShortName = shortName;
        }

        public Display(string name, string description, string group, int displayOrder, string shortName)
            : this(name, description, new[] { group }, displayOrder, shortName)
        {
        }

        public Display(DisplayAttribute attribute)
            : this(attribute.Name, attribute.Description, attribute.GroupName, attribute.Order, attribute.ShortName)
        {
        }
    }
}
