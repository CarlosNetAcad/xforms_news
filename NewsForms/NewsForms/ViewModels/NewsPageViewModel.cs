using System;
using NewsForms.Interfaces;
using NewsForms.Models.API;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using ImTools;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsForms.ViewModels
{
	public class NewsPageViewModel: NavigationViewModel
	{
        private readonly INewsService _newsService;
        private readonly INavigationService _navigationService;
        private string _searchQuery;
        private DateTime _fromDate;
        private bool _isLoading;
        private IList<NewsItem> _newsList;

        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public DateTime FromDate
        {
            get => _fromDate;
            set => SetProperty(ref _fromDate, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public IList<NewsItem> NewsList
        {
            get => _newsList;
            set => SetProperty(ref _newsList, value);
        }

        IList<object> _selectedNewsItem;
        public IList<object> SelectedNewsItem
        {
            get => _selectedNewsItem;
            set
            {
                _selectedNewsItem = value;
                this.RaisePropertyChanged();
            }
        }

        private List<string> _sortByOptions = new List<string>
        {
          "relevancy",
          "popularity",
          "publishedAt"
         };

        public List<string> SortByOptions
        {
            get => _sortByOptions;
            set => SetProperty(ref _sortByOptions, value);
        }

        private string _selectedSortBy;

        public string SelectedSortBy
        {
            get => _selectedSortBy;
            set => SetProperty(ref _selectedSortBy, value);
        }

        public DelegateCommand SearchCommand { get; }
        public ICommand NoteTappedCommand { get; private set; }
        public ICommand SelectionChangedCommand { get; private set; }

        public NewsPageViewModel(INewsService newsService, INavigationService navigationService)
            : base(navigationService)
        {
            _newsService = newsService;
            _navigationService = navigationService;
            Title = "News";
            FromDate = DateTime.Now;
            NewsList = new ObservableCollection<NewsItem>();
            SelectedNewsItem = new List<object>();
            SearchCommand = new DelegateCommand(async () => await SearchNewsAsync());
            NoteTappedCommand = new Command<NewsItem>(OnNoteTappedCommand);
            SelectionChangedCommand = new Command(OnSelectionChangedCommand);

        }

        private async Task SearchNewsAsync()
        {
            try
            {
                IsLoading = true;

                var newsList = await _newsService.GetNewsAsync(SearchQuery, FromDate, SelectedSortBy);

                NewsList.Clear();
                foreach (var newsItem in newsList)
                {
                    NewsList.Add(newsItem);
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            finally
            {
                IsLoading = false;
            }
        }
        private void OnNoteTappedCommand(NewsItem noteViewModel)
        {
            var parameters = new NavigationParameters();
            parameters.Add("NewsItem", noteViewModel);
            NavigationService.NavigateAsync($"{nameof(NewsItemDetailViewModel)}", parameters);
        }
        private void OnSelectionChangedCommand()
        {
            //throw new NotImplementedException();

            foreach (var selectedNote in SelectedNewsItem)
            {
                var note = (NewsItem)selectedNote;
                Console.WriteLine($"Note: {note.Id}");
            }
        }

    }
}

