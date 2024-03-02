using System;
using System.Collections.Generic;

namespace NewsForms.Models.API
{
	public class NewsAPIResponse
	{
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<NewsItem> Articles { get; set; }
    }
}

