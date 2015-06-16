using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace HomeModule
{
    public class HomeModule: IModule
    {
                private readonly IRegionViewRegistry regionViewRegistry;

                public HomeModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;   
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("ToolBarRegion", typeof(SideMenu));
            regionViewRegistry.RegisterViewWithRegion("ContentRegion", typeof(HomeContent));
        }
    }
}
