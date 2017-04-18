using ImmigrationAutoFill.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmigrationAutoFill
{
    class Program
    {


        static void Main(string[] args)
        {
            Global.GlobalDefinition.driver = new ChromeDriver();


            //RegisterPage registerObj = new RegisterPage();
            //registerObj.RegisterStep(3);

            LoginPage loginObj = new LoginPage();
            DetailAutoFill dataObj = new DetailAutoFill();
            PaymentPage payObj = new PaymentPage();


            loginObj.loginSteps(1000); //try login for 1000 times
            
            string url = Global.GlobalDefinition.driver.Url;
            Console.WriteLine("This is url acquired from Program.cs:  " + url);

            //After login, check for url if it's Edit/Submit/Pay
            if (url.Contains("Personal1") && url.Contains("Individual"))
            {
                dataObj.DataFillSteps();
               
            }

            else if (url.Contains("Submit"))
            {
                dataObj.Submit();
            }

            else if (url.Contains("Pay"))
            {
                payObj.PaySteps();

            }


        





        }
    }
}
