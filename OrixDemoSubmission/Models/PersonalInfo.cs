using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrixDemoSubmission.Models
{
    public class PersonalInfo
    {
        [Required(ErrorMessage = "Please first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please last name is required")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please pizza size is required")]
        public PizzaSizes PizzaSize { get; set; }
        public List<Toppings> Topping { get; set; }
        public enum PizzaSizes { Small = 1, Medium = 2, Large = 3 }
    }


    public class Toppings
    {
       
        public int ID { get; set; }
        public string TopName { get; set; }
        public bool IsChecked { get; set; }
    }
}