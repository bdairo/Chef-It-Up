using System;
using System.Collections.Generic;

using testApp.Models;

using Xamarin.Forms;
namespace testApp.Pages
{
    public partial class DetailedPage : ContentPage
    {
        Meal m;
        public DetailedPage(Meal meal)
        {
            m = meal;
            InitializeComponent();
            BindingContext = m;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string ingredients = m.strIngredient1 + "  " + m.strIngredient2 + "  " + m.strIngredient3 + "  " + m.strIngredient4 + "  " + m.strIngredient5 + "  " + m.strIngredient6 + "  " + m.strIngredient7 + "  " + m.strIngredient8 + "  " + m.strIngredient9 + "  " + m.strIngredient10 + "  " + m.strIngredient11 + "  " + m.strIngredient12;
            Info.Text = "\n Instructions \n\n" + m.strInstructions + "\n\n\n\n" + "Ingredients: \n\n" + ingredients + "\n\n\n\n" + m.strYoutube;



        }

        private async void PlayVideo(System.Object sender, System.EventArgs e)
        {
            string videoLink = m.strYoutube;

            if (videoLink != null)
            {
                Application.Current.MainPage = new NavigationPage(new BrowserPage(videoLink));
            }
            else
            {
                await DisplayAlert("Error", "Video Unavailable", "Cancel");
            }
        }

    }
}

































