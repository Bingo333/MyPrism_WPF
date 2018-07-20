using ModuleO.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleO
{
    public class ModuleOModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleOModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewG>();
            _container.RegisterTypeForNavigation<ViewH>();
        }
    }
}