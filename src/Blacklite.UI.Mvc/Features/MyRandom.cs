using Blacklite.Framework.Features;
using Microsoft.Framework.DependencyInjection;
using System;

namespace Blacklite.UI.Mvc.Features
{
    [ServiceDescriptor(typeof(MyRandom))]
    public class MyRandom : Feature.Random
    {

    }
}
