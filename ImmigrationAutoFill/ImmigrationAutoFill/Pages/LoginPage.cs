using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_deleteHyperlink")]
        public IWebElement deleteHyperlink { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_editHyperLink")]
        public IWebElement editHyperLink { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_submitHyperlink")]
        public IWebElement submitHyperlink { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_statusLabel")]
        public IWebElement statusLabel { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_payHyperLink")]
        public IWebElement payHyperLink { get; set; }


        public void loginSteps()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "LoginDetail");

            Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2,"url1"));
            System.Threading.Thread.Sleep(1000);
            Global.GlobalDefinition.driver.Manage().Window.Maximize();
            Global.GlobalDefinition.driver.Navigate().Refresh();

            UsernameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "username"));
            PasswordTextBox.SendKeys(Global.ExcelLib.ReadData(2, "password"));
            LoginBtn.Click();

            Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url2"));

            DataPage dataObj = new DataPage();

            string editStatus = "Incomplete";
            string submitStatus = "Completed pending submission";
            string payStatus = "Submitted";

            string contentText = Global.GlobalDefinition.driver.FindElement(By.XPath("/html/body")).Text;
            Console.WriteLine(contentText);

            string newForm = "If you decide not to submit your application, you can delete it.";
            string existForm = "Reference";

            //Check if there is an existing form
            if (contentText.Contains(newForm))
            {
                
                for (int i = 1; i < 1000; i++)
                {

                    //There is no form
                    SelectElement oSelect = new SelectElement(CountryDropDown);
                    oSelect.SelectByText(Global.ExcelLib.ReadData(2, "country"));
                    OKBtn.Click();
                    try { ApplyBtn.Click(); break; }
                    catch (Exception)
                    {
                        Console.WriteLine("Unfortunately the available places is filled, attemp: {0}", i);
                        Global.GlobalDefinition.driver.Navigate().GoToUrl("https://onlineservices.immigration.govt.nz/WorkingHoliday/");
                        //Thread.Sleep(700);
                        Console.WriteLine(Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='aspnetForm']/table[3]/tbody/tr[2]/td/div/div/p[2]")).Text);
                    }

                }
            }


            else if (contentText.Contains(existForm))
            {
                if (editStatus.Equals(statusLabel.Text))
                {
                    try { editHyperLink.Click(); }
                    catch (Exception) { Console.WriteLine("Sorry, there is no form to edit."); }
                }

                else if (submitStatus.Equals(statusLabel.Text))
                {
                    try { submitHyperlink.Click(); }
                    catch (Exception) { Console.WriteLine("Sorry, you can't submit now."); }

                }
                else if (payStatus.Equals(statusLabel.Text))
                {
                    try { payHyperLink.Click(); }
                    catch (Exception) { Console.WriteLine("Sorry, you can't submit now."); }
                }
            }
            


        }

    }
}
