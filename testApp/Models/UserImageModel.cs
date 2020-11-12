using System;
namespace testApp.Models
{
    public class UserImageModel
    {
        public string imageUrl { get; set; }
        public string FullImagePath => $"http://chefapp6149.azurewebsites.net/{imageUrl}";
    }
}
