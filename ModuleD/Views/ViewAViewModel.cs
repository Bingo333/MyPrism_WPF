using Prism.Mvvm;

namespace ModuleD.Views
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
            Message = "ModuleDRegion -- 跟随变化 ViewModelLocator - 更改约定-更改ViewModelLocator命名约定";
        }
    }
}
