using ModuleG.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleG
{
    public class ModuleGModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleGModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ModuleGRegion", typeof(MessageView));
        }
    }
}