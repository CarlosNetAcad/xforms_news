using System;
using NewsForms.Models.API;
using Prism.Navigation;
using Xamarin.Essentials;

namespace NewsForms.ViewModels
{
    public class NewsItemDetailViewModel : NavigationViewModel
    {

        private NewsItem _selectedNews;

        public NewsItem SelectedNews
        {
            get { return _selectedNews; }
            set { SetProperty(ref _selectedNews, value); }
        }
        private string _urlToImageD;
        public string urlToImageD
        {
            get => _urlToImageD;
            set => SetProperty(ref _urlToImageD, value);
        }
        private string _titleD;
        public string TitleD
        {
            get => _titleD;
            set => SetProperty(ref _titleD, value);
        }
        private DateTime _publishedAtD;
        public DateTime PublishedAtD
        {
            get => _publishedAtD;
            set => SetProperty(ref _publishedAtD, value);
        }
        private string _descriptionD;
        public string DescriptionD
        {
            get => _descriptionD;
            set => SetProperty(ref _descriptionD, value);
        }
        private string _contentD;
        public string ContentD
        {
            get => _contentD;
            set => SetProperty(ref _contentD, value);
        }
        public NewsItemDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Detail News";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.New)
            {
                //get parameters
                SelectedNews = parameters.GetValue<NewsItem>("NewsItem");
                //_noteService = parameters.GetValue<INoteService>("NoteService");
                TitleD = SelectedNews?.Title;
                urlToImageD = SelectedNews?.UrlToImage;
                PublishedAtD = SelectedNews.PublishedAt;
                DescriptionD = SelectedNews?.Description;
                ContentD = SelectedNews?.Content;
            }
        }
    }
}

