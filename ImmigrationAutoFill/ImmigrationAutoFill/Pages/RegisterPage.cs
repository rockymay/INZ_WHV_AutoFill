using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace ImmigrationAutoFill
{
    class RegisterPage
    {
        public RegisterPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }

        [FindsBy(How = How.Id, Using = "registrationDetails_firstNameTextBox")]
        public IWebElement firstNameTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_familyNameTextBox")]
        public IWebElement familyNameTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_emailAddressTextBox")]
        public IWebElement emailAddressTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_userNameTextBox")]
        public IWebElement userNameTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_passwordTextBox")]
        public IWebElement passwordTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_passwordConfirmTextBox")]
        public IWebElement passwordConfirmTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_secretQuestionDropDownList")]
        public IWebElement secretQuestionDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_secretAnswerTextBox")]
        public IWebElement secretAnswerTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "registrationDetails_agreeToConditionsCheckBox")]
        public IWebElement agreeToConditionsCheckBox { get; set; }
        [FindsBy(How = How.Id, Using = "registerImageButton")]
        public IWebElement registerImageButton { get; set; }
        [FindsBy(How = How.Id, Using = "registrationCompleteMessagePanel")]
        public IWebElement actualMessage { get; set; }

        public void RegisterStep()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection("whv.xlsx", "RegisterPage");

            Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url"));
            System.Threading.Thread.Sleep(1000);
            Global.GlobalDefinition.driver.Manage().Window.Maximize();

            firstNameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "firstNameTextBox"));
            familyNameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "familyNameTextBox")); ;
            emailAddressTextBox.SendKeys(Global.ExcelLib.ReadData(2, "emailAddressTextBox")); ;
            userNameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "userNameTextBox")); ;
            passwordTextBox.SendKeys(Global.ExcelLib.ReadData(2, "passwordTextBox")); ;
            passwordConfirmTextBox.SendKeys(Global.ExcelLib.ReadData(2, "passwordTextBox")); ;
            new SelectElement(secretQuestionDropDownList).SelectByIndex(3);
            secretQuestionDropDownList.SendKeys(Global.ExcelLib.ReadData(2, "firstNameTextBox")); ;
            secretAnswerTextBox.SendKeys(Global.ExcelLib.ReadData(2, "secretAnswerTextBox")); ;
            agreeToConditionsCheckBox.ClickAndWait();
            registerImageButton.ClickAndWait();


            string expectMessage = "Thank you for registering with this website.";
            if (expectMessage.Equals(actualMessage.Text))
            {
                Console.WriteLine("Congrats, register successful");
            }

        }
    }
}
