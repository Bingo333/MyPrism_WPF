using ModuleJ.Business;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleJ.ViewModels
{
    public class PersonDetailViewModel : BindableBase
    {
        public PersonDetailViewModel()
        {

        }

        private Person _selectedPerson;

        public Person SelectedPerson { get => _selectedPerson; set => SetProperty(ref _selectedPerson,value); }
    }
}
