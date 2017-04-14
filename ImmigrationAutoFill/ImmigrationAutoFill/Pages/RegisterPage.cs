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

        public void RegisterStep(int line)
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "RegisterPage");

            Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(line, "url"));
            System.Threading.Thread.Sleep(1000);
            Global.GlobalDefinition.driver.Manage().Window.Maximize();

            firstNameTextBox.SendKeys(Global.ExcelLib.ReadData(line, "firstNameTextBox"));
            familyNameTextBox.SendKeys(Global.ExcelLib.ReadData(line, "familyNameTextBox")); ;
            emailAddressTextBox.SendKeys(Global.ExcelLib.ReadData(line, "emailAddressTextBox")); ;
            userNameTextBox.SendKeys(Global.ExcelLib.ReadData(line, "userNameTextBox")); ;
            passwordTextBox.SendKeys(Global.ExcelLib.ReadData(line, "passwordTextBox")); ;
            passwordConfirmTextBox.SendKeys(Global.ExcelLib.ReadData(line, "passwordTextBox")); ;
            new SelectElement(secretQuestionDropDownList).SelectByIndex(3);
            secretQuestionDropDownList.SendKeys(Global.ExcelLib.ReadData(line, "firstNameTextBox")); ;
            secretAnswerTextBox.SendKeys(Global.ExcelLib.ReadData(line, "secretAnswerTextBox")); ;
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
