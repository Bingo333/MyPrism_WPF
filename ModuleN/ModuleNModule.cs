using ModuleN.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleN
{
    public class ModuleNModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleNModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewE>();
            _container.RegisterTypeForNavigation<ViewF>();
        }
    }
}