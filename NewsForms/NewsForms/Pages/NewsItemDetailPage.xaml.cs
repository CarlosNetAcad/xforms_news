using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsForms.Pages
{	
	public partial class NewsItemDetailPage : ContentPage
	{	
		public NewsItemDetailPage (Models.API.NewsItem selectedNewsItem)
		{
			InitializeComponent ();
		}
	}
}

