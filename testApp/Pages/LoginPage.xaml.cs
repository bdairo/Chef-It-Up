using System;
using System.Collections.Generic;
using testApp.Services;


using Xamarin.Forms;

namespace testApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

       private async void BtnBack_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SignupPage());
        }

        private async void loginButtonClicked(System.Object sender, System.EventArgs e)
        {
            var response= await   ApiService.Login(EntEmail.Text, EntPassword.Text);

            if (response)
            {
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid Credentials", "Cancel");
            }
        }


    }
}
