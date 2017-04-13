﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmigrationAutoFill
{
    class DataPage
    {
        public DataPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }
        //PersonalDetail
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_familyNameTextBox")]
        public IWebElement familyNameTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_givenName1Textbox")]
        public IWebElement givenName1Textbox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_genderDropDownList")]
        public IWebElement genderDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_dateOfBithDatePicker_Day")]
        public IWebElement dateOfBithDatePicker_Day { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_dateOfBithDatePicker_Month")]
        public IWebElement dateOfBithDatePicker_Month { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_dateOfBithDatePicker_Year")]
        public IWebElement dateOfBithDatePicker_Year { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_personDetails_CountryDropDownList")]
        public IWebElement countryDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addressContactDetails_address_address1TextBox")]
        public IWebElement address1TextBox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addressContactDetails_address_suburbTextBox")]
        public IWebElement suburbTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addressContactDetails_address_cityTextBox")]
        public IWebElement cityTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addressContactDetails_address_countryDropDownList")]
        public IWebElement countryDropDownListforAddress { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_hasAgent_representedByAgentDropdownlist")]
        public IWebElement hasAgent_representedByAgentDropdownlist { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_communicationMethod_communicationMethodDropDownList")]
        public IWebElement communicationMethodDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_hasCreditCard_hasCreditCardDropDownlist")]
        public IWebElement hasCreditCardDropDownlist { get; set; }
        //General for all pages
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_wizardPageFooter_wizardPageNavigator_nextImageButton")]
        public IWebElement nextImageButton { get; set; }

        //Other
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_passportNumberTextBox")]
        public IWebElement passportNumberTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_confirmPassportNumberTextBox")]
        public IWebElement confirmPassportNumberTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_passportExpiryDateDatePicker_Day")]
        public IWebElement passportExpiryDateDatePicker_Day { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_passportExpiryDateDatePicker_Month")]
        public IWebElement passportExpiryDateDatePicker_Month { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_passportExpiryDateDatePicker_Year")]
        public IWebElement passportExpiryDateDatePicker_Year { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_otherIdentificationDropdownlist")]
        public IWebElement otherIdentificationDropdownlist { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_otherIssueDateDatePicker_Day")]
        public IWebElement otherIssueDateDatePicker_Day { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_otherIssueDateDatePicker_Month")]
        public IWebElement otherIssueDateDatePicker_Month { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_identification_otherIssueDateDatePicker_Year")]
        public IWebElement otherIssueDateDatePicker_Year { get; set; }

        //HEALTH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_wizardPageHeader_nav_sectionTabs_TabHeaders_ctl01_tabButton")]
        public IWebElement TabHeaders_ctl01_tabButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_renalDialysisDropDownList")]
        public IWebElement renalDialysisDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_tuberculosisDropDownList")]
        public IWebElement tuberculosisDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_")]
        public IWebElement cancerDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_heartDiseaseDropDownList")]
        public IWebElement heartDiseaseDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_disabilityDropDownList")]
        public IWebElement disabilityDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_hospitalisationDropDownList")]
        public IWebElement hospitalisationDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_residentailCareDropDownList")]
        public IWebElement residentailCareDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_medicalConditions_tbRiskDropDownList")]
        public IWebElement tbRiskDropDownList { get; set; }



        //CHARACTER
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_wizardPageHeader_nav_sectionTabs_TabHeaders_ctl02_tabButton")]
        public IWebElement TabHeaders_ctl02_tabButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_imprisonment5YearsDropDownList")]
        public IWebElement imprisonment5YearsDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_imprisonment12MonthsDropDownList")]
        public IWebElement imprisonment12MonthsDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_removalOrderDropDownList")]
        public IWebElement removalOrderDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_deportedDropDownList")]
        public IWebElement deportedDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_chargedDropDownList")]
        public IWebElement chargedDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_convictedDropDownList")]
        public IWebElement convictedDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_underInvestigationDropDownList")]
        public IWebElement underInvestigationDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_excludedDropDownList")]
        public IWebElement excludedDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_character_removedDropDownList")]
        public IWebElement removedDropDownList { get; set; }


        //WORKING HOLIDAY SPECIFIC
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_wizardPageHeader_nav_sectionTabs_TabHeaders_ctl03_tabButton")]
        public IWebElement TabHeaders_ctl03_tabButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_commonWHSQuestions_previousWhsPermitVisaDropDownList")]
        public IWebElement previousWhsPermitVisaDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_commonWHSQuestions_sufficientFundsHolidayDropDownList")]
        public IWebElement sufficientFundsHolidayDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_intendedTravelDateDatePicker_Day")]
        public IWebElement intendedTravelDateDatePicker_Day { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_intendedTravelDateDatePicker_Month")]
        public IWebElement intendedTravelDateDatePicker_Month { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_intendedTravelDateDatePicker_Year")]
        public IWebElement intendedTravelDateDatePicker_Year { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_beenToNzDropDownList")]
        public IWebElement beenToNzDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_whenInNZDatePicker_Day")]
        public IWebElement whenInNZDatePicker_Day { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_whenInNZDatePicker_Month")]
        public IWebElement whenInNZDatePicker_Month { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_whenInNZDatePicker_Year")]
        public IWebElement whenInNZDatePicker_Year { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_requirementsQuestions_sufficientFundsOnwardTicketDropDownList")]
        public IWebElement sufficientFundsOnwardTicketDropDownList { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_offshoreDetails_requirementsQuestions_readRequirementsDropDownList")]
        public IWebElement readRequirementsDropDownList { get; set; }



        //SUBMIT
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_wizardPageHeader_nav_submitImageButton")]
        public IWebElement submitImageButton { get; set; }

        

        public void FillingDetail()
        {
            

            //Populate in collection
            Global.ExcelLib.PopulateInCollection("whv.xlsx", "PersonalDetial");

            //PERSONAL
            familyNameTextBox.Clear();
            givenName1Textbox.Clear();
            familyNameTextBox.SendKeys(Global.ExcelLib.ReadData(2, "familyname"));
            givenName1Textbox.SendKeys(Global.ExcelLib.ReadData(2, "surname"));
            new SelectElement(genderDropDownList).SelectByValue(Global.ExcelLib.ReadData(2, "gender"));
            new SelectElement(dateOfBithDatePicker_Day).SelectByValue(Global.ExcelLib.ReadData(2, "birth-day"));
            new SelectElement(dateOfBithDatePicker_Month).SelectByValue(Global.ExcelLib.ReadData(2, "birth-month"));
            new SelectElement(dateOfBithDatePicker_Year).SelectByValue(Global.ExcelLib.ReadData(2, "birth-year"));
            new SelectElement(countryDropDownList).SelectByText("China");

            address1TextBox.SendKeys(Global.ExcelLib.ReadData(2, "street"));
            suburbTextBox.SendKeys(Global.ExcelLib.ReadData(2, "subburb"));
            cityTextBox.SendKeys(Global.ExcelLib.ReadData(2, "city"));

            new SelectElement(countryDropDownListforAddress).SelectByText("China");
            new SelectElement(hasAgent_representedByAgentDropdownlist).SelectByValue("No");
            new SelectElement(communicationMethodDropDownList).SelectByText("Email");
            new SelectElement(hasCreditCardDropDownlist).SelectByValue("Yes");

            nextImageButton.Click();

            //Other Info
            passportNumberTextBox.SendKeys(Global.ExcelLib.ReadData(2, "passport"));
            confirmPassportNumberTextBox.SendKeys(Global.ExcelLib.ReadData(2, "passport"));
            new SelectElement(passportExpiryDateDatePicker_Day).SelectByValue(Global.ExcelLib.ReadData(2, "expire-day"));
            new SelectElement(passportExpiryDateDatePicker_Month).SelectByValue(Global.ExcelLib.ReadData(2, "expire-month"));
            new SelectElement(passportExpiryDateDatePicker_Year).SelectByValue(Global.ExcelLib.ReadData(2, "expire-year"));

            new SelectElement(otherIdentificationDropdownlist).SelectByValue(Global.ExcelLib.ReadData(2, "id"));
            new SelectElement(otherIssueDateDatePicker_Day).SelectByValue(Global.ExcelLib.ReadData(2, "issue-day"));
            new SelectElement(otherIssueDateDatePicker_Month).SelectByValue(Global.ExcelLib.ReadData(2, "issue-month"));
            new SelectElement(otherIssueDateDatePicker_Year).SelectByValue(Global.ExcelLib.ReadData(2, "issue-year"));



            //HEALTH
            TabHeaders_ctl01_tabButton.Click();

            new SelectElement(renalDialysisDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);
            new SelectElement(tuberculosisDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(300);
            new SelectElement(cancerDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);
            new SelectElement(heartDiseaseDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);
            new SelectElement(disabilityDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);
            new SelectElement(hospitalisationDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);
            new SelectElement(residentailCareDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);
            new SelectElement(tbRiskDropDownList).SelectByValue("No");
            System.Threading.Thread.Sleep(100);


            //CHARACTER
            TabHeaders_ctl02_tabButton.Click();

            new SelectElement(imprisonment5YearsDropDownList).SelectByValue("No");
            new SelectElement(imprisonment12MonthsDropDownList).SelectByValue("No");
            new SelectElement(removalOrderDropDownList).SelectByValue("No");
            new SelectElement(deportedDropDownList).SelectByValue("No");
            new SelectElement(chargedDropDownList).SelectByValue("No");
            new SelectElement(convictedDropDownList).SelectByValue("No");
            new SelectElement(underInvestigationDropDownList).SelectByValue("No");
            new SelectElement(excludedDropDownList).SelectByValue("No");
            new SelectElement(removedDropDownList).SelectByValue("No");




            //WORKING HOLIDAY SPECIFIC
            TabHeaders_ctl03_tabButton.Click();

            new SelectElement(previousWhsPermitVisaDropDownList).SelectByValue("No");
            new SelectElement(sufficientFundsHolidayDropDownList).SelectByValue("Yes");
            new SelectElement(intendedTravelDateDatePicker_Day).SelectByValue("11");
            new SelectElement(intendedTravelDateDatePicker_Month).SelectByValue("1");
            new SelectElement(intendedTravelDateDatePicker_Year).SelectByValue("2017");
            new SelectElement(beenToNzDropDownList).SelectByValue(Global.ExcelLib.ReadData(2, "been-to-nz"));
            System.Threading.Thread.Sleep(100);
            new SelectElement(whenInNZDatePicker_Day).SelectByValue(Global.ExcelLib.ReadData(2, "day"));
            new SelectElement(whenInNZDatePicker_Month).SelectByValue(Global.ExcelLib.ReadData(2, "month"));
            new SelectElement(whenInNZDatePicker_Year).SelectByValue(Global.ExcelLib.ReadData(2, "year"));
            new SelectElement(sufficientFundsOnwardTicketDropDownList).SelectByValue("Yes");
            new SelectElement(readRequirementsDropDownList).SelectByValue("Yes");


           nextImageButton.Click();

            //SUBMIT
           //submitImageButton.Click();



        }
    }
}