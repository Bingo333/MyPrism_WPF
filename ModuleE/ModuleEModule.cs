using Microsoft.Practices.Unity;
using ModuleE.ViewModels;
using ModuleE.Views;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleE
{
    public class ModuleEModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleEModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            IRegion region = _regionManager.Regions["ModuleERegion"];

            var tabA = _container.Resolve<TabView>();
            SetTitle(tabA, "Tab A");
            region.Add(tabA);

            var tabB = _container.Resolve<TabView>();
            SetTitle(tabB, "Tab B");
            region.Add(tabB);

            var tabC = _container.Resolve<TabView>();
            SetTitle(tabC, "Tab C");
            region.Add(tabC);
        }

        void SetTitle(TabView tab, string title)
        {
            (tab.DataContext as TabViewModel).Title = title;
        }
    }
}