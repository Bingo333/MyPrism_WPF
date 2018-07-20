using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using UsingCompositeCommands.Core;

namespace ModuleF.ViewModels
{
    //public class TabViewViewModel : BindableBase
    //{
    //    public TabViewViewModel()
    //    {

    //    }
    //}
    /// <summary>
    /// IActiveAware接口，它定义对象实例是否活动，并通知活动何时发生更改。
    /// </summary>
    public class TabViewModel : BindableBase, IActiveAware
    {
        IApplicationCommands _applicationCommands;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updatedText;

        public string UpdateText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;

            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(() => CanUpdate);

            _applicationCommands.SaveCommand.RegisterCommand(UpdateCommand);
        }

        private void Update()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }

        bool _isActive;

        ///获取或设置一个值，该值指示对象是否为活动的。
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnIsActiveChanged();
            }
        }
        private void OnIsActiveChanged()
        {
            //获取或设置一个值，该值指示对象是否为活动的。
            UpdateCommand.IsActive = IsActive;

            IsActiveChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 通知Prism.IActiveAware.IsActive属性的值已更改。
        /// </summary>
        public event EventHandler IsActiveChanged;
    }
}
