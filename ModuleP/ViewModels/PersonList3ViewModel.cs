using ModuleP.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModuleP.ViewModels
{
    public class PersonList3ViewModel : BindableBase, INavigationAware
    {
        IRegionManager _regionManager;
        /// <summary>
        /// 提供对区域内的当前、反向和向前导航的日志记录。
        /// </summary>
        IRegionNavigationJournal _journal;

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public DelegateCommand<Person> PersonSelectedCommand { get; private set; }

        public DelegateCommand GoForwardCommand { get; set; }

        public PersonList3ViewModel(RegionManager regionManager)
        {
            _regionManager = regionManager;

            PersonSelectedCommand = new DelegateCommand<Person>(PersonSelected);
            CreatePeople();

            GoForwardCommand = new DelegateCommand(GoForward, CanGoForward);
        }

        private void PersonSelected(Person person)
        {
            var parameters = new NavigationParameters();
            parameters.Add("person", person);

            if (person != null)
                _regionManager.RequestNavigate("ModulePRegion", "PersonDetail3", parameters);
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

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void GoForward()
        {
            //导航到前向导航历史记录中的最新条目，或者如果前向导航中没有条目，则什么也不做。
            _journal.GoForward();
        }

        private bool CanGoForward()
        {
            return _journal != null && _journal.CanGoForward;
        }
    }
}