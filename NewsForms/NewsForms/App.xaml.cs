using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using NewsForms.Interfaces;
using NewsForms.Pages;
using NewsForms.Services;
using NewsForms.ViewModels;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsForms
{
    public partial class App : PrismApplication
    {
        public App() : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {
        }

        protected override void OnInitialized()
        {
            //start my app and ui
            NavigationService.NavigateAsync($"NavigationPage/{nameof(NewsPageViewModel)}");
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=f5ab0dd1-b0b1-4404-95b7-28b4db79ccde;" +
                 "ios=8b104163-9126-455b-9248-ffb5fee103db;",
                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register services
            containerRegistry.RegisterSingleton<INewsService, APINewsService>();
            containerRegistry.RegisterSingleton<ITrackerService, AppCenterTrackerService>();

            //register pages
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //register pages for navigation
            containerRegistry.RegisterForNavigation<NewsPage, NewsPageViewModel>($"{nameof(NewsPageViewModel)}");
            containerRegistry.RegisterForNavigation<NewsItemDetailPage, NewsItemDetailViewModel>($"{nameof(NewsItemDetailViewModel)}");

        }
    }
}

