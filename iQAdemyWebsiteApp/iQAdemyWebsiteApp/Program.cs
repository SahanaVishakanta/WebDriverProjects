﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace iQAdemyWebsiteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://www.integrationqa.com/");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement menu = driver.FindElement(By.Id("hs_menu_wrapper_module_13970568219884"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(menu).Build().Perform();

            IList<IWebElement> menuItemsList = menu.FindElements(By.ClassName("hs-menu-item"));

            String[] menuItems = new String[menuItemsList.Count];
            int i = 0;
            foreach (IWebElement menuItem in menuItemsList)
            {
                menuItems[i++] = menuItem.Text;
            }

            //Arrange all the list items in alphabetical order
            IEnumerable<String> orderedMenuList = menuItems.OrderBy(lv_menu => lv_menu).ToList();

            //Display the ordered list
            foreach (var menuItem in orderedMenuList)
            {
                if (menuItem.Length > 0)
                    Console.WriteLine(menuItem);
            }
            Console.ReadKey();
        }
    }
}
