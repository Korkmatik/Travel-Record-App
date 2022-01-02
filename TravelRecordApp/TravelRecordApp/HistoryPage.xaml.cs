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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Post> posts;
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                posts = connection.Table<Post>().ToList();
            }

            postListView.ItemsSource = posts;
        }

        private void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Post selectedPost = ((ListView)sender).SelectedItem as Post;
            if (selectedPost == null)
            {
                return;
            }

            Navigation.PushAsync(new PostDetailPage(selectedPost));
        }
    }
}