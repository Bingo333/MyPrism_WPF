using ModuleB.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleBModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // 把占位符ContentRegion跟ViewA绑定并显示出来
            _regionManager.RegisterViewWithRegion("ModuleBRegion", typeof(ViewA));
        }
    }
}