using System;
using System.Collections.Generic;
using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using testApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace testApp.Pages
{
    public partial class MyAccountPage : ContentPage
    {
        private MediaFile file;


        public MyAccountPage()
        {
            InitializeComponent();
        }

        void TapUploadImage_Tapped(System.Object sender, System.EventArgs e)
        {
            PickImageFromGallery();
        }
        private async void PickImageFromGallery()
        {

            await CrossMedia.Current.Initialize();

            if ( !CrossMedia.Current.IsTakePhotoSupported)
            {
               await DisplayAlert("No Camera", ":( Your device does not support this feature.", "OK");
                return;
            }

             file = await CrossMedia.Current.PickPhotoAsync();
          
            if (file == null)
                return;

           // await DisplayAlert("File Location", file.Path, "OK");

            var x = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                AddImageToServer();
                return stream;            });

            ImgProfile.Source = x;

        }


        private async void AddImageToServer()
        {
            var imageArray = FromFile.ToArray(file.GetStream());  //convert image stream to byte array;
            file.Dispose();
            var response = await ApiService.EditUserProfile(imageArray);
            if (response) return;
            await DisplayAlert("Something went wrong", "Upload again", "Cancel");

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var profileImage = await ApiService.GetUserProfileImage();
            Console.WriteLine(profileImage);
            
            if (string.IsNullOrEmpty(profileImage.imageUrl))
            {
                ImgProfile.Source = "image.jpg";
            }

            else
            {
                ImgProfile.Source = profileImage.FullImagePath;
                label.Text = "Change Profile Picture";
            }

        }

        private void TapLogout_Tapped(object sender,EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Application.Current.MainPage = new NavigationPage(new LoginPage());
;
        }
    }
}
