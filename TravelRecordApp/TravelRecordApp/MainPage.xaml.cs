using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(txtEmail.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(txtPassword.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return;
            }

            Navigation.PushAsync(new HomePage());
        }
    }
}
