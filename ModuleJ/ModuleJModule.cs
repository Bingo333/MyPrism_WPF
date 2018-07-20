using ModuleJ.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace ModuleJ
{
    public class ModuleJModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleJModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // 将 PersonList 注册到主界面并显示出来
            _regionManager.RegisterViewWithRegion("ModuleJRegion", typeof(PersonList));

            // 将 PersonDetail 注册到 PersonList 界面并显示出来
            _regionManager.RegisterViewWithRegion("PersonDetailsRegion", typeof(PersonDetail));
        }
    }
}