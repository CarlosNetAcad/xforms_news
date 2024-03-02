using System;
using NewsForms.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewsForms.Models.API;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;

namespace NewsForms.Services
{
	public class APINewsService: INewsService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public APINewsService()
        {
            _apiKey = "073975eb50124b8682a442a5ff560fee";
            _baseUrl = "https://newsapi.org/v2/";

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "HttpClient");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

        }

        public async Task<IList<NewsItem>> GetNewsAsync(string query, DateTime from,string SelectedSortBy)
        {
            var url = $"everything?q={query}&from={from:yyyy-MM-dd}&sortBy={SelectedSortBy}";

            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var newsApiResponse = JsonConvert.DeserializeObject<NewsAPIResponse>(content);
                return newsApiResponse.Articles;
            }
            else
            {
                throw new Exception($"Error al obtener noticias: {response.StatusCode}");
            }
        }

    }
}

