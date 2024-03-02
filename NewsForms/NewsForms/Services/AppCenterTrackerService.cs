using System;
using Microsoft.AppCenter.Analytics;
using NewsForms.Interfaces;

namespace NewsForms.Services
{
	public class AppCenterTrackerService : ITrackerService
    {
        public void TrackEvent(string eventName)
        {
            Analytics.TrackEvent(eventName);
        }
    }
}

