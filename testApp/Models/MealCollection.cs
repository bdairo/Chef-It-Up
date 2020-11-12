using System;
using System.Collections.Generic;
using System.Text;
namespace testApp.Models
{
    public class MealCollection
    {
        private List<Meal> meals;
        public List<Meal> Meals { get => meals; set => meals = value; }
    }
}
