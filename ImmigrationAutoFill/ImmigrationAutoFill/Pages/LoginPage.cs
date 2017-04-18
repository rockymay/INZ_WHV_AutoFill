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

        //[FindsBy(How = How.Id, Using = "OnlineServicesLoginStealth_VisaLoginControl_userNameTextBox")]
        //public IWebElement UsernameTextBox { get; set; }

        //[FindsBy(How = How.Id, Using = "OnlineServicesLoginStealth_VisaLoginControl_passwordTextBox")]
        //public IWebElement PasswordTextBox { get; set; }

        //[FindsBy(How = How.Id, Using = "OnlineServicesLoginStealth_VisaLoginControl_loginImageButton")]
        //public IWebElement LoginBtn { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_countryDropDownList")]
        //public IWebElement CountryDropDown { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_okButton")]
        //public IWebElement OKBtn { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applyNowButton")]
        //public IWebElement ApplyBtn { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_deleteHyperlink")]
        //public IWebElement deleteHyperlink { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_editHyperLink")]
        //public IWebElement editHyperLink { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_submitHyperlink")]
        //public IWebElement submitHyperlink { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_statusLabel")]
        //public IWebElement statusLabel { get; set; }

        //[FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_applicationList_applicationsDataGrid_ctl02_payHyperLink")]
        //public IWebElement payHyperLink { get; set; }


        public void loginSteps(int loopNumber)
        {
            var globalDrive = Global.GlobalDefinition.driver;
            
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "LoginDetail");


            //Save some string

            string editStatus = Global.ExcelLib.ReadData(2, "preDefinedMessage");
            string submitStatus = Global.ExcelLib.ReadData(3, "preDefinedMessage");
            string payStatus = Global.ExcelLib.ReadData(4, "preDefinedMessage");
            string newForm = Global.ExcelLib.ReadData(5, "preDefinedMessage");
            string existForm = Global.ExcelLib.ReadData(6, "preDefinedMessage");
            string noPlaceMessage = Global.ExcelLib.ReadData(7, "preDefinedMessage");
            string warningMessage = Global.ExcelLib.ReadData(8, "preDefinedMessage");
            

            //Navigate to
            globalDrive.Navigate().GoToUrl(Global.ExcelLib.ReadData(2,"url1"));
            System.Threading.Thread.Sleep(1000);
            globalDrive.Manage().Window.Maximize();
 

            Console.WriteLine(Global.ExcelLib.ReadData(2, "locatorValue"));
            Console.WriteLine(Global.ExcelLib.ReadData(2, "username"));
            Global.GlobalDefinition.TextBox(globalDrive, "Id", (Global.ExcelLib.ReadData(2, "locatorValue")), (Global.ExcelLib.ReadData(2, "username")));
          
            Global.GlobalDefinition.TextBox(globalDrive, "Id", Global.ExcelLib.ReadData(3, "locatorValue"), Global.ExcelLib.ReadData(2, "password"));
            Global.GlobalDefinition.ActionButton(globalDrive, "Id", Global.ExcelLib.ReadData(4, "locatorValue"));

            globalDrive.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url2"));
            


            string contentText = Global.GlobalDefinition.Element(globalDrive, "XPath", Global.ExcelLib.ReadData(13, "locatorValue")).Text;
            

            //Check if there is an existing form
            if (contentText.Contains(newForm))
            {
                
                for (int i = 1; i < loopNumber; i++)
                {

                    //There is no form
                    SelectElement oSelect = new SelectElement(Global.GlobalDefinition.Element(globalDrive, "Id", Global.ExcelLib.ReadData(5, "locatorValue")));
                    oSelect.SelectByText(Global.ExcelLib.ReadData(2, "country"));
                    //OKBtn.Click();
                    Global.GlobalDefinition.ActionButton(globalDrive, "Id", Global.ExcelLib.ReadData(6, "locatorValue"));
                    try
                    {
                        Global.GlobalDefinition.ActionButton(globalDrive, "Id", Global.ExcelLib.ReadData(7, "locatorValue")); //Apply Button

                        Console.WriteLine("Form taken at time: " + DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                       
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(noPlaceMessage + i);
                        Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url2"));
                        //Thread.Sleep(700);
                        Console.Write(Global.GlobalDefinition.Element(globalDrive, "XPath", Global.ExcelLib.ReadData(14, "locatorValue")).Text);
                    }

                }
            }

            //When you have form and it might be NOT COMPLETED/ COMPLETED YET SUBMITTED/ SUBMITTED YET PAID
            else if (contentText.Contains(existForm))
            {
                //Not completed
                if (editStatus.Equals(Global.GlobalDefinition.Element(globalDrive, "Id", Global.ExcelLib.ReadData(12, "locatorValue")).Text))
                {
                    try { Global.GlobalDefinition.ActionButton(globalDrive, "Id", Global.ExcelLib.ReadData(9, "locatorValue")); }
                    catch (Exception) { Console.WriteLine(warningMessage); }
                }
                //Not submitted
                else if (submitStatus.Equals(Global.GlobalDefinition.Element(globalDrive, "Id", Global.ExcelLib.ReadData(12, "locatorValue")).Text))
                {
                    try { Global.GlobalDefinition.ActionButton(globalDrive, "Id", Global.ExcelLib.ReadData(10, "locatorValue")); }
                    catch (Exception) { Console.WriteLine(warningMessage); }
                }
                //Not paid
                else if (payStatus.Equals(Global.GlobalDefinition.Element(globalDrive, "Id", Global.ExcelLib.ReadData(12, "locatorValue")).Text))
                {
                    try { Global.GlobalDefinition.ActionButton(globalDrive, "Id", Global.ExcelLib.ReadData(11, "locatorValue")); }
                    catch (Exception) { Console.WriteLine(warningMessage); }
                }
            }
        }
    }
}
