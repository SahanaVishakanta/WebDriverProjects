using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace SeleniumMasterWebsiteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://www.seleniummaster.com/");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement menu = driver.FindElement(By.Id("menubar"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(menu).Build().Perform();

            IList<IWebElement> menuItemsList = menu.FindElements(By.Id("menu"));
            char[] delim = { '\r', '\n' };
            String[] menuList = menuItemsList[0].Text.Split(delim);

            //Query to orderby all the list items
            IEnumerable<string> orderedMenuList = menuList.OrderBy(lv_menu => lv_menu).ToList();

            //Display the ordered list
            foreach (string menuItem in orderedMenuList)
            {
                if (menuItem.Length > 0)
                    Console.WriteLine(menuItem);
            }
            Console.ReadKey();
        }
    }
}
