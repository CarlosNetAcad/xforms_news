﻿using System;
using Prism.Mvvm;

namespace NewsForms.ViewModels
{
	public class BaseViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

    }
}

