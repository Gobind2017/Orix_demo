using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrixDemoSubmission.Models;
using static OrixDemoSubmission.Models.PersonalInfo;
using System.Text;

namespace OrixDemoSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PersonalInfo info)
        {                      
            TempData["personInfo"] = info; 
            return RedirectToAction("topping", "Home");
        }
        public ActionResult PersonDetail()
        {
            //var person = new List<PersonalInfo>
            // {
            //     new PersonalInfo { FirstName="gobind" ,LastName="Rauniyar",Address="123 street", PhoneNumber="9728155931",EmailAddress="Email@email.com" },
            //     new PersonalInfo { FirstName="Jhon" ,LastName="hungry",Address="1234 street", PhoneNumber="8728155930",EmailAddress="Email@email.com" },
            //     new PersonalInfo { FirstName="Mike" ,LastName="trend",Address="123432 road", PhoneNumber="7728155936",EmailAddress="Email@email.com" },
            //     new PersonalInfo { FirstName="sweety" ,LastName="berumen",Address="12323 drive", PhoneNumber="6728155934",EmailAddress="Email@email.com"},
            // };
            // var single = from s in person
            //              where s.PhoneNumber == id
            ////              select s;
            //select new PersonalInfo()
            //{
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    Address = s.Address,
            //    PhoneNumber = s.PhoneNumber,
            //    EmailAddress = s.EmailAddress,
            //};

           
            // return View(single);
            return View();
        }
        public ActionResult Topping()
        {
            //Toppings orders = new Toppings();
            var info = (PersonalInfo)TempData["personInfo"];
            TempData.Keep();
            if (TempData["personInfo"] != null)
            {
                ViewBag.welcome = "Hello " + info.FirstName + ", Please Select topping of your choice:";
            }
                List<Toppings> y = new List<Toppings>
           // var y = new List<Toppings>
            {
                new Toppings{ ID=1, TopName = "Cheese", IsChecked = true},
                 new Toppings{ ID=1, TopName = "Chicken", IsChecked = false},
                 new Toppings{ ID=2, TopName = "Olives", IsChecked = false},
                 new Toppings{ ID=3, TopName = "Peporinni", IsChecked = false},
                 new Toppings{ ID=4, TopName = "Mushroom", IsChecked = false},
                 new Toppings{ ID=5, TopName = "Spinach", IsChecked = false},
                 new Toppings{ ID=6, TopName = "Pineapple", IsChecked = false},

            };

            return View(y);
        }
        [HttpPost]
        public ActionResult Topping(IEnumerable <Toppings> top)
        {
            // this will take to confirmation page 
            var info = (PersonalInfo)TempData["personInfo"];
            StringBuilder msg = new StringBuilder();
            if (top.Count(x => x.IsChecked) == 0)
            {
                msg.Append("You didn't select any topping");
            }
            else
            {
                msg.Append("You have selected ");
                foreach (Toppings item in top)
                {
                    if (item.IsChecked)
                    {
                        msg.Append(item.TopName + " ,");
                    }
                }
                msg.Remove(msg.ToString().LastIndexOf(','), 1);
                msg.Append(" as your toopings.");
                
            }
            var DT = DateTime.Now.AddMinutes(20);
            ViewBag.message = @" Thank you " + info.FirstName + " for your order.<br /> Your "
                                    + info.PizzaSize + " Pizza will be ready in 20 minutes( " + DT + ").<br />" +
                                     msg;
            
            //return ViewBag.message;
            return View("Confirmation");
        }

        public ActionResult Confirmation ()
        {
            return View();
        }        
        public ActionResult MakeNewOrder()
        {
            TempData.Remove("personInfo");
            return RedirectToAction("Index");
        }

        
    }
}
