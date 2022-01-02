using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
        }

        private void tiSave_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text,
                Latitude = double.Parse(latitudeEntry.Text),
                Longitude = double.Parse(longitudeEntry.Text)
            };

            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            connection.CreateTable<Post>();
            int rows = connection.Insert(post);
            connection.Close();

            if (rows > 0)
            {
                DisplayAlert("Success", "Experience successfully inserted", "OK");
            }
            else
            {
                DisplayAlert("Failure", "Experience failed to be insert", "OK");
            }
        }
    }
}