using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using testApp.Models;

namespace testApp.Pages
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Navigation.PushAsync(new DetailedPage());

            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            Meal selectedMeal = (Meal)lv.SelectedItem;
            Console.WriteLine(selectedMeal);

            // assuiming Club has an Id property
            //await Navigation.PushAsync(new DetailedClub(club.Id));
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button Pressed");
            Console.WriteLine(sakchham.Text.ToLower());
            string APIBase = "http://www.themealdb.com/api/json/v1/1/search.php?s=";
            string APIlink = APIBase + sakchham.Text.ToLower();
            JsonDeserialize(APIlink);
        }

        private void DisplayAlert(string aPIlink)
        {
            throw new NotImplementedException();
        }

        public void JsonSerialize(object data, string filePath)
        {

        }

        public void JsonDeserialize(string url)
        {
            WebClient client = new WebClient();

            string myJSON = client.DownloadString(url);

            MealCollection mealCollection = JsonConvert.DeserializeObject<MealCollection>(myJSON);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Meal meal = JsonConvert.DeserializeObject<Meal>(myJSON, settings);
            Console.WriteLine(mealCollection.Meals.Count);
            myList.ItemsSource = mealCollection.Meals;



        }

        void myList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Meal details = (Meal)e.Item;
            Navigation.PushAsync(new DetailedPage(details));
        }
    }
}
