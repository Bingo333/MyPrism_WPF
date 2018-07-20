using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleN.ViewModels
{
    public class ViewEViewModel : BindableBase, IConfirmNavigationRequest
    {
        public ViewEViewModel()
        {

        }

        /// <summary>
        /// 确定此实例是否接受正在导航的实例。
        /// 此方法的实现者不需要在完成该方法之前调用回调，但必须确保调用回调。
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            if (MessageBox.Show("Do you to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                result = false;

            // 如果continuationCallback(result)中result == true,则离开本页进入新页,如果为否则继续停留在本页不进入新页
            continuationCallback(result);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

    }
}
