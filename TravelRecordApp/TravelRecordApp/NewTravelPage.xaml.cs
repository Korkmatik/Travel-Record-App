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

        private void tiSave_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
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