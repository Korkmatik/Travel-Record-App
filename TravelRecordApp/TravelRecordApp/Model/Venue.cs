using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(Constants.VENUE_SEARCH, latitude, longitude, Secrets.CLIENT_ID, Secrets.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
