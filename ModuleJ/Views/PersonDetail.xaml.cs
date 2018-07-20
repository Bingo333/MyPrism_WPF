using System.Windows.Controls;
using ModuleJ.Business;
using ModuleJ.ViewModels;
using Prism.Common;
using Prism.Regions;

namespace ModuleJ.Views
{
    /// <summary>
    /// Interaction logic for PersonDetail
    /// </summary>
    public partial class PersonDetail : UserControl
    {
        public PersonDetail()
        {
            InitializeComponent();
            #region RegionContext-使用RegionContext将数据传递给嵌套区域
            RegionContext.GetObservableContext(this).PropertyChanged += PersonDetail_PropertyChanged;
            #endregion
        }

        #region RegionContext-使用RegionContext将数据传递给嵌套区域
        private void PersonDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = (ObservableObject<object>)sender;
            var selectedPerson = (Person)context.Value;
            (DataContext as PersonDetailViewModel).SelectedPerson = selectedPerson;
        }
        #endregion

    }
}
