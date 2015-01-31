using Blacklite.Framework;
using Blacklite.Framework.Metadata.Modeling.Metadatums;
using Blacklite.Framework.Metadata.Mvc;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.TagHelpers;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Framework.OptionsModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Blacklite.UI.Mvc.TagHelpers
{
    public sealed class ControlTagHelper : TagHelper
    {
        private const string ForAttributeName = "for";
        private const string ClassAttributeName = "class";
        private const string LabelClassAttributeName = "label-class";
        private const string ControlClassAttributeName = "control-class";
        private const string DescriptionClassAttributeName = "description-class";
        private const string HelpClassAttributeName = "help-class";
        

        [Activate]
        private IOptions<ControlTagHelperOptions> _options { get; set; }

        protected internal ControlTagHelperOptions Options { get { return _options.Options; } }

        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal IControlGenerator Generator { get; set; }

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(ClassAttributeName)]
        public string Class { get; set; }

        [HtmlAttributeName(LabelClassAttributeName)]
        public string LabelClass { get; set; }

        [HtmlAttributeName(ControlClassAttributeName)]
        public string ControlClass { get; set; }

        [HtmlAttributeName(DescriptionClassAttributeName)]
        public string DescriptionClass { get; set; }

        [HtmlAttributeName(HelpClassAttributeName)]
        public string HelpClass { get; set; }

        /// <inheritdoc />
        /// <remarks>Does nothing if <see cref="For"/> is <c>null</c>.</remarks>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (For != null)
            {
                if (output.ContentSet)
                {
                    var childContent = await context.GetChildContentAsync();

                    if (!string.IsNullOrWhiteSpace(childContent))
                    {
                        output.Content = childContent;
                    }
                    else
                    {
                        output.Content = GetContainer(context, output);
                    }
                }
                else
                {
                    output.Content = GetContainer(context, output);
                }


                //var tagBuilder = Generator.GenerateLabel(ViewContext,
                //                                         For.Metadata,
                //                                         For.Name,
                //                                         labelText: null,
                //                                         htmlAttributes: null);
            }
        }

        private string GetContainer(TagHelperContext context, TagHelperOutput output)
        {
            var tagBuilder = Generator.GenerateContainer(ViewContext, For.Metadata, Options, For.Name, Class, LabelClass, ControlClass, DescriptionClass, HelpClass);
            output.MergeAttributes(tagBuilder);
            return tagBuilder.InnerHtml;
        }
    }

    public class ControlTagHelperOptions
    {
        public ControlTagHelperOptions()
        {
        }

        public ControlTagHelperOptionsCssClassContainer Classes { get; } = new ControlTagHelperOptionsCssClassContainer();
    }

    public enum ControlTagItem
    {
        Container,
        ControlContainer,
        Control,
        Label,
        Help,
        Description,
        ValidationSummary
    }

    public class ControlTagHelperOptionsCssClassContainer
    {
        private readonly IDictionary<ControlTagItem, ICollection<string>> _items = new Dictionary<ControlTagItem, ICollection<string>>();
        public ICollection<string> this[ControlTagItem item]
        {
            get
            {
                ICollection<string> value;
                if (!_items.TryGetValue(item, out value))
                {
                    value = new Collection<string>();
                    _items.Add(item, value);
                }

                return value;
            }
        }
    }

    class ControlTagHelperOptionsSetup : ConfigureOptions<ControlTagHelperOptions>
    {
        public ControlTagHelperOptionsSetup() : base(Configure)
        {
        }

        public static void Configure(ControlTagHelperOptions options)
        {

        }
    }

    class BootstrapControlTagHelperOptionsSetup : ConfigureOptions<ControlTagHelperOptions>
    {
        public BootstrapControlTagHelperOptionsSetup() : base(Configure)
        {
        }

        public static void Configure(ControlTagHelperOptions options)
        {
            options.Classes[ControlTagItem.Container].Add("form-group");
            options.Classes[ControlTagItem.Label].Add("col-sm-2");
            options.Classes[ControlTagItem.Label].Add("control-label");
            options.Classes[ControlTagItem.ControlContainer].Add("col-sm-10");
            options.Classes[ControlTagItem.Control].Add("form-control");
            options.Classes[ControlTagItem.Description].Add("help-block");
        }
    }

    public interface IControlGenerator
    {
        TagBuilder GenerateContainer([NotNull] ViewContext viewContext, [NotNull] ModelMetadata modelMetadata, [NotNull] ControlTagHelperOptions options, string name, string classes, string labelClasses, string controlClasses, string descriptionClasses, string helpClasses, object htmlAttributes = null);

        TagBuilder GenerateLabel([NotNull] ViewContext viewContext, [NotNull] ModelMetadata modelMetadata, [NotNull] ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null);

        TagBuilder GenerateControl([NotNull] ViewContext viewContext, [NotNull] ModelMetadata modelMetadata, [NotNull] ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null);

        TagBuilder GenerateControlContainer([NotNull] ViewContext viewContext, [NotNull] ModelMetadata modelMetadata, [NotNull] ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null);

        TagBuilder GenerateHelpText([NotNull] ViewContext viewContext, [NotNull] ModelMetadata modelMetadata, [NotNull] ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null);

        TagBuilder GenerateDescription([NotNull] ViewContext viewContext, [NotNull] ModelMetadata modelMetadata, [NotNull] ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null);
    }

    class ControlGenerator : IControlGenerator
    {
        private readonly IHtmlGenerator _htmlGenerator;
        public ControlGenerator(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }

        public static string GetClasses(ControlTagHelperOptions options, string classes, ControlTagItem item)
        {
            if (classes == null && !options.Classes[item].Any())
            {
                return string.Empty;
            }

            if (classes == null)
            {
                return string.Join(" ", options.Classes[item]);
            }

            if (!options.Classes[item].Any())
            {
                return classes;
            }
                
            return string.Join(" ", classes
                .Split(' ')
                .Union(options.Classes[item])
                .Distinct());
        }

        public TagBuilder GenerateContainer(ViewContext viewContext, ModelMetadata modelMetadata, ControlTagHelperOptions options, string name, string classes, string labelClasses, string controlClasses, string descriptionClasses, string helpClasses, object htmlAttributes = null)
        {
            var metadata = modelMetadata.AsMetadata();
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder("div");
            builder.AddCssClass(GetClasses(options, classes, ControlTagItem.Container));

            var label = GenerateLabel(viewContext, modelMetadata, options, name, labelClasses);
            var controlContainer = GenerateControlContainer(viewContext, modelMetadata, options, name, controlClasses);
            // bootstrap
            var controlCls = string.Join(" ", (controlClasses ?? string.Empty).Split(' ').Where(x => !x.StartsWith("col-")));
            // /bootstrap
            var control = GenerateControl(viewContext, modelMetadata, options, name, controlCls);
            var description = GenerateDescription(viewContext, modelMetadata, options, name, descriptionClasses);

            controlContainer.InnerHtml = control.ToString(TagRenderMode.SelfClosing);
            builder.InnerHtml = label.ToString();
            builder.InnerHtml += controlContainer.ToString();
            builder.InnerHtml += description.ToString();

            return builder;
        }

        public TagBuilder GenerateControlContainer(ViewContext viewContext, ModelMetadata modelMetadata, ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null)
        {
            var metadata = modelMetadata.AsMetadata();
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder("div");

            classes = GetClasses(options, classes, ControlTagItem.ControlContainer);

            builder.AddCssClass(classes);
            return builder;
        }

        public TagBuilder GenerateControl(ViewContext viewContext, ModelMetadata modelMetadata, ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null)
        {
            var metadata = modelMetadata.AsMetadata();
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = _htmlGenerator.GenerateTextBox(viewContext, modelMetadata, name, modelMetadata.Model, modelMetadata.EditFormatString, htmlAttributes);

            builder.Attributes.Add("placeholder", metadata.Get<DisplayName>());
            classes = GetClasses(options, classes, ControlTagItem.Control);

            builder.AddCssClass(classes);
            return builder;
        }

        public TagBuilder GenerateDescription(ViewContext viewContext, ModelMetadata modelMetadata, ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null)
        {
            var metadata = modelMetadata.AsMetadata();
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder("div");

            classes = GetClasses(options, classes, ControlTagItem.Description);

            builder.AddCssClass(classes);
            return builder;
        }

        public TagBuilder GenerateHelpText(ViewContext viewContext, ModelMetadata modelMetadata, ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null)
        {
            var metadata = modelMetadata.AsMetadata();
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder("div");

            classes = GetClasses(options, classes, ControlTagItem.Help);

            builder.AddCssClass(classes);
            return builder;
        }

        public TagBuilder GenerateLabel(ViewContext viewContext, ModelMetadata modelMetadata, ControlTagHelperOptions options, string name, string classes = null, object htmlAttributes = null)
        {
            var metadata = modelMetadata.AsMetadata();
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = _htmlGenerator.GenerateLabel(viewContext, modelMetadata, name, metadata.Get<DisplayName>(), htmlAttributes);

            if (metadata.Get<Required>())
                builder.InnerHtml += "*";

            classes = GetClasses(options, classes, ControlTagItem.Label);

            builder.AddCssClass(classes);
            return builder;
        }
    }
}