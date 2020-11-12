using System;
using System.Collections.Generic;
using testApp.Services;
using Xamarin.Forms;

namespace testApp.Pages
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(System.Object sender, System.EventArgs e)
        {


            var response=await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);

            if (response)
            {
                await DisplayAlert("Hi", "Your account is sucessfully created", "Okay");
                await Navigation.PushModalAsync(new LoginPage());
            }


            else
            {
                await DisplayAlert("Opps", "Account cannot be created", "Cancel");

            }

        }

        private async void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
