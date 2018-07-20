using ModuleP.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleP.ViewModels
{
    public class PersonDetail3ViewModel : BindableBase, INavigationAware
    {
        private Person _selectedPerson;
        IRegionNavigationJournal _journal;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public DelegateCommand GoBackCommand { get; set; }

        public PersonDetail3ViewModel()
        {
            GoBackCommand = new DelegateCommand(GoBack);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;

            var person = navigationContext.Parameters["person"] as Person;
            if (person != null)
                SelectedPerson = person;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters["person"] as Person;
            if (person != null)
                return SelectedPerson != null && SelectedPerson.LastName == person.LastName;
            else
                return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void GoBack()
        {
            // 导航到返回导航历史记录中的最新条目，或者如果后面导航中没有条目，则什么也不做。
            _journal.GoBack();
        }
    }
}
