using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Vjezba2.Test.FunctionalTests
{
    class TestManagerSetup
    {
        public static void Click(WebDriverWait wait, string xpath)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();
        }

        public static void SendKeysById(WebDriverWait wait, string id, string input)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(id))).SendKeys(input);
        }
    }
}
