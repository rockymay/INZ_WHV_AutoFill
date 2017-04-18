using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImmigrationAutoFill.Pages
{
   
    class DetailAutoFill
    {
        PaymentPage payObj = new PaymentPage();




        public DetailAutoFill()  //Constructor
        {
            //Globalize driver
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);

            


        }

        public void CheckTableFilled(ref bool[] pageTable)
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");



            for (int i = 0; i < 4; i++)
            {
                string statusImage = Global.GlobalDefinition.Element(Global.GlobalDefinition.driver, "Id", "ctl00_ContentPlaceHolder1_wizardPageHeader_nav_sectionTabs_TabHeaders_ctl0" + i + "_statusImage").GetAttribute("src");
                Console.WriteLine(statusImage);
                pageTable[i] = statusImage.Contains("error") ? false : true;
            }


        }
        private bool[] pageTable = new bool[4];

        public void DataFillSteps()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");

           
            CheckTableFilled(ref pageTable);
            
            //string profileIcon = Global.GlobalDefinition.Element(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(2, "pageIcon"))).GetAttribute("src");
            //string healthIcon = Global.GlobalDefinition.Element(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "pageIcon")).GetAttribute("src");
            //string characterIcon = Global.GlobalDefinition.Element(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "pageIcon")).GetAttribute("src");
            //string WHVIcon = Global.GlobalDefinition.Element(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "pageIcon")).GetAttribute("src");
            //Console.WriteLine(profileIcon);
            //Console.WriteLine(healthIcon);
            //Console.WriteLine(characterIcon);
            //Console.WriteLine(WHVIcon);
            //pageTable[0] = profileIcon.Contains("error") ? true : false;
            //pageTable[1] = healthIcon.Contains("error") ? true : false;
            //pageTable[2] = characterIcon.Contains("error") ? true : false;
            //pageTable[3] = WHVIcon.Contains("error") ? true : false;
            foreach (bool item in pageTable) { Console.WriteLine(item); }



            Console.WriteLine("pageTable: "); 
            foreach (bool item in pageTable) { Console.WriteLine(item); }

           for (int i = 0; i<10; i++)
            {
                if (pageTable[0] && pageTable[1] && pageTable[2] && pageTable[3])
                {
                    try
                    {
                        Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(12, "pageTab")));
                        Submit();
                    }
                    catch (Exception) { Console.WriteLine("Oh oh, you cant submit now."); }
                }
                else
                {
                    if (!pageTable[0]) { Personal(); }
                    else
                    {
                        if (!pageTable[1]) { Health(); }
                        else
                        {
                            if (!pageTable[2]) { Character(); }
                            else
                            {
                                if (!pageTable[3]) { WHV(); }
                            }
                        }
                    }
                }
            }
        }

        

        public void Personal()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");

            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id",  (Global.ExcelLib.ReadData(2, "pageTab")));
            //First & Last Name  &&  Address, Suburb, City, Country
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "personalDetail"), (Global.ExcelLib.ReadData(2, "name")));
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "personalDetail"), (Global.ExcelLib.ReadData(3, "name")));
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(9, "personalDetail"), (Global.ExcelLib.ReadData(2, "address")));
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(10, "personalDetail"), (Global.ExcelLib.ReadData(3, "address")));
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(11, "personalDetail"), (Global.ExcelLib.ReadData(4, "address")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(12, "personalDetail"), "46");
            //Gender & DOB
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "personalDetail"), (Global.ExcelLib.ReadData(4, "name")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "personalDetail"), (Global.ExcelLib.ReadData(5, "name")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(6, "personalDetail"), (Global.ExcelLib.ReadData(6, "name")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(7, "personalDetail"), (Global.ExcelLib.ReadData(7, "name")));
            //Country
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(8, "personalDetail"), "46");
            //Agent?Email?VisaCard?
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(13, "personalDetail"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(14, "personalDetail"), "1");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(15, "personalDetail"), "Yes");

            //Next
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(8, "pageTab")));

            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "personalOther"), (Global.ExcelLib.ReadData(2, "id1")));
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "personalOther"), (Global.ExcelLib.ReadData(2, "id1")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "personalOther"), (Global.ExcelLib.ReadData(3, "id1")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "personalOther"), (Global.ExcelLib.ReadData(4, "id1")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(6, "personalOther"), (Global.ExcelLib.ReadData(5, "id1")));
            //Other ID
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(7, "personalOther"), "3");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(8, "personalOther"), (Global.ExcelLib.ReadData(3, "id2")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(9, "personalOther"), (Global.ExcelLib.ReadData(4, "id2")));
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(10, "personalOther"), (Global.ExcelLib.ReadData(5, "id2")));

            //Save
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(7, "pageTab")));

            CheckTableFilled(ref pageTable);
        }

        public void Health()
        {

            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");

            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(3, "pageTab")));

            string message = "Please try again later.";
            

            for (int i = 2; i < 10; i++)
            {
                Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(i, "health")), "No");
                Thread.Sleep(500);
                if (message == Global.GlobalDefinition.driver.FindElement(By.XPath("/html/body")).Text)
                {
                    string url = Global.GlobalDefinition.driver.Url;
                    Global.GlobalDefinition.driver.Navigate().GoToUrl(url);
                }
            }
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(6, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(7, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(8, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(9, "health"), "No");
            //Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(10, "health"), "No");
            //Save
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(7, "pageTab")));
            CheckTableFilled(ref pageTable);
        }

        public void Character()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");

            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(4, "pageTab")));

            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(6, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(7, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(8, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(9, "character"), "No");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(10, "character"), "No");
            //Save
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(7, "pageTab")));

            CheckTableFilled(ref pageTable);
        }

        public void WHV()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");


            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(5, "pageTab")));
            //Previously hold WHV?
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "whv"), "No");
            //Enough fund?
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "whv"), "Yes");
            //Intend travel day
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "whv"), "30");
            //Intend travel month
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "whv"), "11");
            //Intend travel year
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(6, "whv"), "2017");
            //Previous been to NZ?
            string beentoNZ = Global.ExcelLib.ReadData(2, "been-to-nz");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(7, "whv"), beentoNZ);

            switch (beentoNZ)
            {
                case "Yes":
                    Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(8, "whv"), Global.ExcelLib.ReadData(3, "been-to-nz"));
                    Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(9, "whv"), Global.ExcelLib.ReadData(4, "been-to-nz"));
                    Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(10, "whv"), Global.ExcelLib.ReadData(5, "been-to-nz"));
                    break;
                case "No": break;
                default: break;
            }
            //Enough Fund?
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(11, "whv"), "Yes");
            Global.GlobalDefinition.DropDown(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(12, "whv"), "Yes");
            //Save
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", (Global.ExcelLib.ReadData(7, "pageTab")));

            CheckTableFilled(ref pageTable);
        }

        public void Submit()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(@"C:\Users\rockymay\Desktop\whv.xlsx", "PersonalDetail");

            for (int i=2; i<14; i++)
            {
                Console.WriteLine(i);
                Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(i, "submitCheck"));
            }
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(4, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(5, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(6, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(7, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(8, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(9, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(10, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(11, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(12, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(13, "submitCheck"));
            //Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(14, "submitCheck"));


        }
    }
}
