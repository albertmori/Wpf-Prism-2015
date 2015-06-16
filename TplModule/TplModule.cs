using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using TplModule.Views;

namespace TplModule
{
    public class TplModule: IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public TplModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("ContentRegion", typeof(TplView));
        }
    }
}

