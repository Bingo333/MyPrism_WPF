using MyPrism_WPF.Notifications;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPrism_WPF.ViewModels
{
    public class UsingPopupWindowActionViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// InteractionRequest--实现Prism.Interactivity.InteractionRequest.IInteractionRequest接口.
        /// INotification--表示用于通知的交互请求。
        /// </summary>
        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public DelegateCommand NotificationCommand { get; set; }

        /// <summary>
        /// IConfirmation--表示用于确认的交互请求。
        /// </summary>
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public DelegateCommand ConfirmationCommand { get; set; }

        public InteractionRequest<INotification> CustomPopupRequest { get; set; }
        public DelegateCommand CustomPopupCommand { get; set; }

        public UsingPopupWindowActionViewModel()
        {
            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseNotification);

            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            ConfirmationCommand = new DelegateCommand(RaiseConfirmation);

            CustomPopupRequest = new InteractionRequest<INotification>();
            CustomPopupCommand = new DelegateCommand(RaiseCustomPopup);

            CustomNotificationRequest = new InteractionRequest<ICustomNotification>();
            CustomNotificationCommand = new DelegateCommand(RaiseCustomInteraction);
        }

        void RaiseNotification()
        {
            // 触发Raised事件
            NotificationRequest.Raise(new Notification { Content = "Notification Message", Title = "Notification" }, r => Title = "Notified");
        }

        void RaiseConfirmation()
        {
            ConfirmationRequest.Raise(new Confirmation
            {
                Title = "Confirmation",
                Content = "Confirmation Message"
            },
                r => Title = r.Confirmed ? "Confirmed" : "Not Confirmed");
        }

        void RaiseCustomPopup()
        {
            CustomPopupRequest.Raise(new Notification { Title = "Custom Popup", Content = "Custom Popup Message " }, r => Title = "Good to go");
        }


        #region 交互性 - 自定义请求-创建您自己的自定义请求以使用InteractionRequest
        public InteractionRequest<ICustomNotification> CustomNotificationRequest { get; set; }
        public DelegateCommand CustomNotificationCommand { get; set; }
        private void RaiseCustomInteraction()
        {
            CustomNotificationRequest.Raise(new CustomNotification { Title = "Custom Notification" }, r =>
            {
                if (r.Confirmed && r.SelectedItem != null)
                    Title = $"User selected: { r.SelectedItem}";
                else
                    Title = "User cancelled or didn't select an item";
            });
        }
        #endregion
    }
}
