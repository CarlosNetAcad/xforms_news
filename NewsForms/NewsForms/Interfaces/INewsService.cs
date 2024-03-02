using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsForms.Models.API;

namespace NewsForms.Interfaces
{
	public interface INewsService
	{
        Task<IList<NewsItem>> GetNewsAsync(string query, DateTime from, string SelectedSortBy);
    }
}

