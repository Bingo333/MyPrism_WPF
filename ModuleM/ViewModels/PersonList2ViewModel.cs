using ModuleM.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModuleM.ViewModels
{
    public class PersonList2ViewModel : BindableBase
    {
        IRegionManager _regionManager;

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public DelegateCommand<Person> PersonSelectedCommand { get; private set; }

        public PersonList2ViewModel(RegionManager regionManager)
        {
            _regionManager = regionManager;

            PersonSelectedCommand = new DelegateCommand<Person>(PersonSelected);
            CreatePeople();
        }

        private void PersonSelected(Person person)
        {
            var parameters = new NavigationParameters();
            parameters.Add("person", person);

            // 传递参数
            if (person != null)
                _regionManager.RequestNavigate("PersonDetail2Region", "PersonDetail2", parameters);
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person()
                {
                    FirstName = String.Format("First {0}", i),
                    LastName = String.Format("Last {0}", i),
                    Age = i
                });
            }

            People = people;
        }
    }
}
