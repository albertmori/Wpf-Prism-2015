using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using RXModule.Views;

namespace RXModule
{
    public class RXModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public RXModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("ContentRegion", typeof(RXView));
        }
    }
}
