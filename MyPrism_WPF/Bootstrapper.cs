using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using ModuleB;
using ModuleD;
using ModuleE;
using ModuleF;
using ModuleG;
using ModuleH;
using ModuleJ;
using ModuleK;
using ModuleL;
using ModuleM;
using ModuleN;
using ModuleO;
using ModuleP;
using MyPrism_WPF.Prism;
using MyPrism_WPF.Views;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using UsingCompositeCommands.Core;

namespace MyPrism_WPF
{
    /// <summary>
    /// 继承自Prism框架, 这里的UnityBootstrapper-代表的底层是通过Unity作为IOC容器的.也可以采用MEF作为底层IOC容器
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// "this.Container" -> UnityContainer
        /// 创建主界面-也就是我们程序的主界面.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            // 创建主界面-也就是我们程序的主界面.
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 还记得Module中的初始化方法吗,Module中的初始化方法,将Region占位符给替换为具体的界面,这样在上面的CreateShell方法中,如果发现shell中出现Region对应的占位符,就用Module中设置的字典映射,动态匹配,找到Region对应的界面,替换Shell中指定的位置.
        /// </summary>
        protected override void InitializeShell()
        {
            // 显示主界面
            Application.Current.MainWindow.Show();
        }

        //protected override void ConfigureModuleCatalog()
        //{
        //    var moduleCatalog = (ModuleCatalog)ModuleCatalog;
        //    //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        //}

        /// <summary>
        /// 自定义区域适配器,为StackPanel创建一个自定义区域适配器
        /// </summary>
        /// <returns></returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;

            //view discovery -- 把占位符ContentRegion跟ViewA绑定并显示出来
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        #region 带有App.config的模块-使用App.config文件加载模块
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new ConfigurationModuleCatalog();
        //}
        #endregion

        #region 带有代码的模块-使用代码加载模块
        //protected override void ConfigureModuleCatalog()
        //{
        //    var catalog = (ModuleCatalog)ModuleCatalog;
        //    catalog.AddModule(typeof(ModuleBModule));
        //    catalog.AddModule(typeof(ModuleEModule));
        //}
        #endregion

        #region 带目录的模块-从目录加载模块
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }
        #endregion

        #region 模块手动加载-使用IModuleManager手动加载模块
        protected override void ConfigureModuleCatalog()
        {
            var moduleDType = typeof(ModuleDModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleDType.Name,
                ModuleType = moduleDType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ModuleBModule));

            #region CompositeCommands-了解如何使用CompositeCommands作为单个命令调用多个命令
            catalog.AddModule(typeof(ModuleEModule));
            #endregion

            #region IActiveAware命令-使您的命令IActiveAware只调用活动命令
            catalog.AddModule(typeof(ModuleFModule));
            #endregion

            #region 事件聚合器-使用IEventAggregator
            catalog.AddModule(typeof(ModuleGModule));
            catalog.AddModule(typeof(ModuleHModule));
            #endregion

            #region RegionContext-使用RegionContext将数据传递给嵌套区域
            catalog.AddModule(typeof(ModuleJModule));
            #endregion

            #region 地区导航-了解如何实现基本的区域导航
            catalog.AddModule(typeof(ModuleKModule));
            #endregion

            #region 导航参与-通过INavigationAware了解View和ViewModel导航参与
            catalog.AddModule(typeof(ModuleLModule));
            #endregion

            #region 传递参数-将参数从View / ViewModel传递到另一个View / ViewModel
            catalog.AddModule(typeof(ModuleMModule));
            #endregion

            #region 确认/取消导航-使用IConfirmNavigationReqest界面确认或取消导航
            catalog.AddModule(typeof(ModuleNModule));
            #endregion

            #region 控制视图的生命周期-使用IRegionMemberLifetime自动从内存中删除视图
            catalog.AddModule(typeof(ModuleOModule));
            #endregion

            #region 导航日志-了解如何使用导航日志
            catalog.AddModule(typeof(ModulePModule));
            #endregion
        }
        #endregion

        #region ViewModelLocator - 更改约定-更改ViewModelLocator命名约定
        //// 注意,一旦更改约定,所有的Module的View也会采用这个约定去匹配ViewModel
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    // SetDefaultViewTypeToViewModelTypeResolver--设置View绑定的默认ViewModel
        //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        //    {
        //        // View的完全限定名称  viewName == MyPrism_WPF.Views.MainWindow
        //        var viewName = viewType.FullName;

        //        // Viewr的程序集名称 viewAssemblyName == MyPrism_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
        //        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

        //        // 设置ViewModel的类型的程序集限定名称 viewModelName == MyPrism_WPF.Views.MainWindowViewModel, MyPrism_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
        //        var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";

        //        // 获取ViewModel的Type并返回  Type.GetType(viewModelName) == {Name = "MainWindowViewModel" FullName = "MyPrism_WPF.Views.MainWindowViewModel"}
        //        return Type.GetType(viewModelName);
        //    });
        //}
        #endregion

        #region ViewModelLocator - 自定义注册-为特定视图手动注册ViewModels
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(ViewModels.CustomViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<ViewModels.CustomViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<ViewModels.CustomViewModel>());

            // generic type
            ViewModelLocationProvider.Register<MainWindow, ViewModels.CustomViewModel>();
        }
        #endregion

        #region CompositeCommands-了解如何使用CompositeCommands作为单个命令调用多个命令
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
        }
        #endregion
    }
}
