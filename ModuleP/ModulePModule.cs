using ModuleP.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleP
{
    public class ModulePModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModulePModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<PersonList3>();
            _container.RegisterTypeForNavigation<PersonDetail3>();

            _regionManager.RequestNavigate("ModulePRegion", "PersonList3");
        }
    }
}