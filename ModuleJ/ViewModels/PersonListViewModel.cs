﻿using System;
using System.Collections.ObjectModel;
using ModuleJ.Business;
using Prism.Mvvm;

namespace ModuleJ.ViewModels
{
    public class PersonListViewModel : BindableBase
    {
        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get => _people;
            set => SetProperty(ref _people,value);
        }

        public PersonListViewModel()
        {
            CreatePeople();
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person()
                {
                    FirstName = $"First {i}",
                    LastName = $"Last {i}",
                    Age = i
                });
            }

            People = people;
        }
    }
}
