using ModuleM.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleM
{
    public class ModuleMModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleMModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ModuleMRegion", typeof(PersonList2));

            _container.RegisterTypeForNavigation<PersonDetail2>();
        }
    }
}