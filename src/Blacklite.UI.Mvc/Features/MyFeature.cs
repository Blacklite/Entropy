using Blacklite.Framework.Features;
using Microsoft.Framework.DependencyInjection;
using System;

namespace Blacklite.UI.Mvc.Features
{
    [ServiceDescriptor(typeof(MyFeature))]
    public class MyFeature : Feature.AlwaysOn
    {

    }
}
