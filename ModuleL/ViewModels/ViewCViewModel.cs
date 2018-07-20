using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleL.ViewModels
{
    public class ViewCViewModel : BindableBase, INavigationAware
    {
        private string _title = "INavigationAware-ViewA";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public ViewCViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        /// <summary>
        /// 当从其它页面导航至本页面的时候，首先会调用IsNavigationTarget，IsNavigationTarget返回一个bool值，简单地说这个方法的作用就是告诉Prism，是重复使用这个视图的实例还是再创建一个。true--重复使用; false--再创建一个;然后调用OnNavigatedTo方法。在导航到本页面的时候，就可以从navigationContext中取出传递过来的参数。
        /// </summary>
        /// <param name="navigationContext">导航传递的上下文,可以从navigationContext中取出传递过来的参数</param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 当从本页面转到其它页面的时候，会调用OnNavigatedFrom方法，navigationContext会包含目标页面的URI。
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
