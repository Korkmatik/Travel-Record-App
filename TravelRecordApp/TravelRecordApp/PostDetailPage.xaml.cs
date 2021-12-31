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
    public partial class PostDetailPage : ContentPage
    {
        Post post;

        public PostDetailPage(Post post)
        {
            InitializeComponent();

            this.post = post;

            experienceEntry.Text = post.Experience;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            post.Experience = experienceEntry.Text;

            int rows;
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                rows = connection.Update(post);
            }

            if (rows > 0)
            {
                DisplayAlert("Success", "Experience successfully updated", "OK");
            }
            else
            {
                DisplayAlert("Failure", "Experience failed to be updated", "OK");
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            int rows;
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                rows = connection.Delete(post);
            }

            if (rows > 0)
            {
                DisplayAlert("Success", "Experience successfully deleted", "OK");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Failure", "Experience failed to be deleted", "OK");
            }
        }
    }
}