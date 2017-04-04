using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Tests
{
    public class CandidateTest : IDisposable
    {
        IWebDriver Driver;
        public CandidateTest()
            : base()
        {
            var capabilities = DesiredCapabilities.Chrome();
            Driver = new RemoteWebDriver(new Uri("http://localhost:9515"), capabilities);
        }


        public CandidateTest GoToForms()
        {
            Driver.Navigate().GoToUrl("http://localhost:57720/Home/Login");
            return this;
        }

        public CandidateTest CreateNewAccount()
        {
            Driver.FindElement(By.LinkText("create account")).Click();
            return this;
        }


        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

    }
}
