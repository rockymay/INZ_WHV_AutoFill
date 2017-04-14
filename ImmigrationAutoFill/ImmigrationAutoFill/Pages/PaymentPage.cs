using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace ImmigrationAutoFill
{
    class PaymentPage
    {
        public PaymentPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }
        //Payment Detail


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_onlinePaymentAnchor")]
        public IWebElement onlinePaymentAnchor { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_payorNameTextBox")]
        public IWebElement payorNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_okImageButton")]
        public IWebElement okImageButton { get; set; }

        [FindsBy(How = How.Id, Using = "card_type_VISA")]
        public IWebElement card_type_VISA { get; set; }

        [FindsBy(How = How.Id, Using = "card_type_MASTERCARD")]
        public IWebElement card_type_MASTERCARD { get; set; }

        [FindsBy(How = How.Id, Using = "cardnumber")]
        public IWebElement cardnumber { get; set; }

        [FindsBy(How = How.Id, Using = "cardverificationcode")]
        public IWebElement cardverificationcode { get; set; }

        [FindsBy(How = How.Id, Using = "expirymonth")]
        public IWebElement expirymonth { get; set; }

        [FindsBy(How = How.Id, Using = "expiryyear")]
        public IWebElement expiryyear { get; set; }

        [FindsBy(How = How.Id, Using = "cardholder")]
        public IWebElement cardholder { get; set; }

        [FindsBy(How = How.Id, Using = "pay_button")]
        public IWebElement pay_button { get; set; }


        




        public void PaySteps()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PaymentDetail");
           
            //PERSONAL
            onlinePaymentAnchor.Click();
            payorNameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "carholder"));
            okImageButton.Click();
            card_type_VISA.Click();
            cardnumber.SendKeys(Global.ExcelLib.ReadData(2, "cardnumber"));
            cardverificationcode.SendKeys(Global.ExcelLib.ReadData(2, "cvc"));
            new SelectElement(expirymonth).SelectByText((Global.ExcelLib.ReadData(2, "month")));
            new SelectElement(expiryyear).SelectByText((Global.ExcelLib.ReadData(2, "year")));
            cardholder.SendKeys(Global.ExcelLib.ReadData(2, "carholder"));
            pay_button.Click();



        }
    }
}
