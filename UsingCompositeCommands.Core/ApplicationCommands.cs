
#region CompositeCommands-了解如何使用CompositeCommands作为单个命令调用多个命令
using Prism.Commands;

namespace UsingCompositeCommands.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        #region CompositeCommands-了解如何使用CompositeCommands作为单个命令调用多个命令
        //private CompositeCommand _saveCommand = new CompositeCommand();
        #endregion

        #region IActiveAware命令-使您的命令IActiveAware只调用活动命令
        private CompositeCommand _saveCommand = new CompositeCommand(true);
        #endregion

        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }
    }
}
#endregion