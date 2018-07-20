using ModuleD.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleD
{
    public class ModuleDModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleDModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ModuleDRegion", typeof(ViewA));
        }
    }
}