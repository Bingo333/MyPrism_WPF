using ModuleL.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleL
{
    public class ModuleLModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleLModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            #region 导航参与-通过INavigationAware了解View和ViewModel导航参与
            _container.RegisterTypeForNavigation<ViewC>();
            _container.RegisterTypeForNavigation<ViewD>();
            #endregion
        }
    }
}