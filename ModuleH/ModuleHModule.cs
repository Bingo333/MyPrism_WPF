using ModuleH.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleH
{
    public class ModuleHModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleHModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ModuleHRegion", typeof(MessageList));
        }
    }
}