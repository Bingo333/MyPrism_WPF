using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace MyPrism_WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        #region 查看发现-使用View Discovery自动注入视图
        //// 需要屏蔽下面的 public MainWindow(IUnityContainer container, IRegionManager regionManager) 才能正常显示出来
        //public MainWindow(IRegionManager regionManager)
        //{
        //    InitializeComponent();
        //    //view discovery -- 把占位符ContentRegion跟ViewA绑定并显示出来
        //    regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        //}
        #endregion


        #region 查看注射-使用View Injection手动添加和删除视图
        ///// <summary>
        ///// 定义统一依赖注入容器的行为的接口。
        ///// </summary>
        //IUnityContainer _container;

        ///// <summary>
        ///// 定义一个接口来管理Prism.Regions.IRegion的集合，并将区域附加到对象（通常是控件）。
        ///// </summary>
        //IRegionManager _regionManager;

        //public MainWindow(IUnityContainer container, IRegionManager regionManager)
        //{
        //    InitializeComponent();
        //    _container = container;
        //    _regionManager = regionManager;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    // 从容器中解析默认请求类型的实例。获得ViewA的实例
        //    var view = _container.Resolve<ViewA>();

        //    // 获取通过名称标识每个区域的Prism.Regions区域集合。
        //    // 可以使用此集合向当前区域管理器添加或删除区域。
        //    IRegion region = _regionManager.Regions["ContentRegion"];

        //    // 把ViewA的实例跟region绑定并显示出来
        //    region.Add(view);
        //}
        #endregion

        #region 查看激活/停用-手动激活和停用视图
        //IUnityContainer _container;
        //IRegionManager _regionManager;
        //IRegion _region;

        //ViewA _viewA;
        //ViewB _viewB;

        //public MainWindow(IUnityContainer container, IRegionManager regionManager)
        //{
        //    InitializeComponent();
        //    _container = container;
        //    _regionManager = regionManager;

        //    this.Loaded += MainWindow_Loaded;
        //}

        //private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _viewA = _container.Resolve<ViewA>();
        //    _viewB = _container.Resolve<ViewB>();

        //    _region = _regionManager.Regions["ContentRegion"];

        //    //一个Region可以添加多个View,默认显示第一个添加的View
        //    _region.Add(_viewA);
        //    _region.Add(_viewB);
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //activate view a
        //    _region.Activate(_viewA);
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    //deactivate view a
        //    _region.Deactivate(_viewA);
        //}

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    //activate view b
        //    _region.Activate(_viewB);
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    //deactivate view b
        //    _region.Deactivate(_viewB);
        //}
        #endregion

        #region 模块手动加载-使用IModuleManager手动加载模块
        IModuleManager _moduleManager;
        public MainWindow(IModuleManager moduleManager)
        {
            InitializeComponent();
            _moduleManager = moduleManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _moduleManager.LoadModule("ModuleDModule");
        }
        #endregion
    }
}
