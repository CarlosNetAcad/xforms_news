using System;
using Prism.Navigation;

namespace NewsForms.ViewModels
{
	public class NavigationViewModel : BaseViewModel, INavigationAware
    {
        protected INavigationService NavigationService { get; private set; }

        public NavigationViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}

