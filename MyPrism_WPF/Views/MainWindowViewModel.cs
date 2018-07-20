using Prism.Mvvm;

namespace MyPrism_WPF.Views
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "ViewModelLocator - 更改约定-更改ViewModelLocator命名约定";
        public string Title
        {
            get { return _title; }
            //set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
