using ModuleM.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleM.ViewModels
{
    public class PersonDetail2ViewModel : BindableBase, INavigationAware
    {
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public PersonDetail2ViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 取得传递过来的参数
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
    }
}
