using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            LoginPage loginObj = new LoginPage();
            loginObj.loginSteps();

            DataPage dataObj = new DataPage();
            dataObj.FillingDetail();



        }
    }
}
