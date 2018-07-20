using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UsingEventAggregator.Core;

namespace ModuleH.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        /// <summary>
        /// 定义一个事件聚合器
        /// </summary>
        IEventAggregator _ea;

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessageListViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Messages = new ObservableCollection<string>();

            // GetEvent -> 获取一个事件类型的实例.
            // Subscribe -> 订阅将在Prism.Events.ThreadOption.PublisherThread上发布的事件的委托.Prism.Events.PubSubEvent`1将维护一个System.WeakReference到所提供的动作委托的目标
            //_ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);

            #region 事件聚合器 - 过滤事件-订阅事件时过滤事件
            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.PublisherThread, false, (filter) => filter.Contains("123"));
            #endregion
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="message"></param>
        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
