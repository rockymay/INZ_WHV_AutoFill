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
            loginObj.loginSteps();

            DataPage dataObj = new DataPage();
            PaymentPage payObj = new PaymentPage();

            string url = Global.GlobalDefinition.driver.Url;


            if (url.Contains("Personal"))
            {
                dataObj.FillingDetail();
                dataObj.SubmitPressed();

            }

            else if (url.Contains("Submit"))
            {
                dataObj.SubmitPressed();
            }

            else if (url.Contains("Pay"))
            {
                payObj.PaySteps();

            }


            
           




        }
    }
}
