using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using MyPrism_WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MyPrism_WPF.ViewModels
{
    public class CustomViewModel : BindableBase
    {
        private string _title = "Custom ViewModel Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //public CustomViewModel()
        //{

        //}

        #region DelegateCommand-使用DelegateCommand和 DelegateCommand<T>
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
                //RaiseCanExecuteChanged->针对每个命令发布Prism.Commands.DelegateCommandBase.CanExecuteChanged
                //如果命令可以执行则调用查询操作检查.注意,这个对每个调用会触发执行一次
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _updateText;
        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }


        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }

        public DelegateCommand DelegateCommandObservesProperty { get; private set; }

        public DelegateCommand DelegateCommandObservesCanExecute { get; private set; }


        public CustomViewModel()
        {
            // Execute->执行方法  CanExecute->可否执行的函数
            ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);

            //ObservesProperty -> 观察一个实现了INotifyPropertyChanged的属性，并在属性值发生变化后自动生成调用DelegateCommandBase.RaiseCanExecuteChanged
            DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);

            //ObservesCanExecute -> 观察一个使用了确定此命令是否可以执行并且实现了INotifyPropertyChanged的属性，并在属性值发生变化后自动生成调用DelegateCommandBase.RaiseCanExecuteChanged
            DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);

            ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => IsEnabled);

            
        }

        private void Execute()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }

        private void ExecuteGeneric(string parameter)
        {
            UpdateText = parameter;
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }
        #endregion

        #region CompositeCommands-了解如何使用CompositeCommands作为单个命令调用多个命令
        //private IApplicationCommands _applicationCommands;
        //public IApplicationCommands ApplicationCommands
        //{
        //    get { return _applicationCommands; }
        //    set { SetProperty(ref _applicationCommands, value); }
        //}

        //public CustomViewModel(IApplicationCommands applicationCommands)
        //{
        //    ApplicationCommands = applicationCommands;
        //}
        #endregion

        #region 地区导航-了解如何实现基本的区域导航
        private readonly IRegionManager _regionManager;
        public CustomViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);

            #region 控制视图的生命周期-使用IRegionMemberLifetime自动从内存中删除视图
            // 当集合更改时发生。
            _regionManager.Regions.CollectionChanged += Regions_CollectionChanged;
            #endregion

            #region 交互性 - 通知请求-了解如何使用InteractionRequest显示弹出窗口
            _regionManager.RegisterViewWithRegion("UsingPopupWindowActionRegion", typeof(UsingPopupWindowAction));
            #endregion

            #region 交互性 - InvokeCommandAction-调用命令以响应任何事件
            Items = new List<string>();

            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
            Items.Add("Item5");

            // This command will be executed when the selection of the ListBox in the view changes.
            SelectedCommand = new DelegateCommand<object[]>(OnItemSelected);

            // 传递控件本身的事件参数
            SelectedWithEventParaCommand = new DelegateCommand<EventArgs>(Para => this.OnSelectedWithEventPara(Para));
            #endregion
        }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ModuleKRegion", navigatePath);
        }
        #endregion

        #region 导航回调-导航完成时收到通知
        public DelegateCommand<string> NavigateCallbackCommand {
            get { return new DelegateCommand<string>(NavigateCallback); }
        }
        private void NavigateCallback(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ModuleKRegion", navigatePath, NavigationComplete);
        }

        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }
        #endregion

        #region 导航参与-通过INavigationAware了解View和ViewModel导航参与
        public DelegateCommand<string> NavigateINavigationAwareCommand
        {
            get { return new DelegateCommand<string>(NavigateINavigationAware); }
        }
        private void NavigateINavigationAware(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ModuleLRegion", navigatePath);
        }
        #endregion

        #region 确认/取消导航-使用IConfirmNavigationReqest界面确认或取消导航
        public DelegateCommand<string> NavigateIConfirmNavigationReqestCommand
        {
            get { return new DelegateCommand<string>(NavigateIConfirmNavigationReqest); }
        }
        private void NavigateIConfirmNavigationReqest(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ModuleNRegion", navigatePath);
        }
        #endregion

        #region 控制视图的生命周期-使用IRegionMemberLifetime自动从内存中删除视图
        private ObservableCollection<object> _views = new ObservableCollection<object>();
        public ObservableCollection<object> Views
        {
            get { return _views; }
            set { SetProperty(ref _views, value); }
        }

        public DelegateCommand<string> NavigateIRegionMemberLifetimeCommand
        {
            get { return new DelegateCommand<string>(NavigateIRegionMemberLifetime); }
        }
        private void NavigateIRegionMemberLifetime(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ModuleORegion", navigatePath);
        }

        /// <summary>
        /// 当集合更改时发生调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Regions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Prism.Regions.RegionManager.RegionCollection
            //RegionManager rm = sender as RegionManager;
            //rm.Regions.CollectionChanged
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var region = (IRegion)e.NewItems[0];
                region.Views.CollectionChanged += Views_CollectionChanged;
            }
        }

        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Views.Add(e.NewItems[0].GetType().Name);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Views.Remove(e.OldItems[0].GetType().Name);
            }
        }
        #endregion

        #region 交互性 - InvokeCommandAction-调用命令以响应任何事件
        //注意 CustomViewModel(IRegionManager regionManager) 中涉及本例的初始化代码
        private string _selectedItemText;
        public string SelectedItemText
        {
            get { return _selectedItemText; }
            private set { SetProperty(ref _selectedItemText, value); }
        }

        public IList<string> Items { get; private set; }

        public DelegateCommand<object[]> SelectedCommand { get; private set; }

        public DelegateCommand<EventArgs> SelectedWithEventParaCommand { get; private set; }
        
        private void OnSelectedWithEventPara(EventArgs e)
        {
            System.Windows.Controls.SelectionChangedEventArgs arg = e as System.Windows.Controls.SelectionChangedEventArgs;

            MessageBox.Show($"Type:{e.ToString()}\r\nAddedItems:{arg.AddedItems[0].ToString()}\r\nRemovedItems:{(arg.RemovedItems.Count < 1 ? null : arg.RemovedItems[0].ToString())}");
        }

        private void OnItemSelected(object[] selectedItems)
        {
            if (selectedItems != null && selectedItems.Count() > 0)
            {
                SelectedItemText = selectedItems.FirstOrDefault().ToString();
            }
        }
        #endregion
    }
}