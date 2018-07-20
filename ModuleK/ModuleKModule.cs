using ModuleK.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleK
{
    public class ModuleKModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleKModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            #region 地区导航-了解如何实现基本的区域导航
            _container.RegisterTypeForNavigation<ViewA>();
            _container.RegisterTypeForNavigation<ViewB>();
            #endregion
        }
    }
}