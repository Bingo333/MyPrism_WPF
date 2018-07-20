using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using UsingEventAggregator.Core;

namespace ModuleG.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        /// <summary>
        /// 定义一个事件聚合器
        /// </summary>
        IEventAggregator _ea;

        private string _message = "只发送包含'123'的消息";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        private void SendMessage()
        {
            // GetEvent -> 获取一个事件类型的实例.
            // Publish -> 发布 Prism.Events.PubSubEvent`1.
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
