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
    class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }


        [FindsBy(How = How.Id, Using = "OnlineServicesLoginStealth_VisaLoginControl_userNameTextBox")]
        public IWebElement UsernameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "OnlineServicesLoginStealth_VisaLoginControl_passwordTextBox")]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "OnlineServicesLoginStealth_VisaLoginControl_loginImageButton")]
        public IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_countryDropDownList")]
        public IWebElement CountryDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_okButton")]
        public IWebElement OKBtn { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applyNowButton")]
        public IWebElement ApplyBtn { get; set; }


        public void loginSteps()
        {
            
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\whv.xlsx", "LoginDetail");

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2,"url1"));
            System.Threading.Thread.Sleep(1000);
            

            UsernameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "username"));
            PasswordTextBox.SendKeys(Global.ExcelLib.ReadData(2, "password"));
            LoginBtn.Click();

            driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url2"));



            try
            {
                SelectElement oSelect = new SelectElement(CountryDropDown);
                oSelect.SelectByText(Global.ExcelLib.ReadData(2, "country"));
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }

            OKBtn.Click();
            ApplyBtn.Click();

        }

    }
}
