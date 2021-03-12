﻿using RCG.WPF.State.Navigators;
using RCG.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace RCG.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IProductManagerViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IProductManagerViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}