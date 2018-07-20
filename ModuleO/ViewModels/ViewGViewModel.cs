using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleO.ViewModels
{
    public class ViewGViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        public ViewGViewModel()
        {

        }

        /// <summary>
        /// 获取一个值，该值指示此实例在停用时是否应保持活着。
        /// </summary>
        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
