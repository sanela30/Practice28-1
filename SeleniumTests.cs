using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Practice28_1
{
    internal class SeleniumTests
    {
        IWebDriver driver;
        WebDriverWait wait;
        /*
        [Test]
        public void TestHomePage()
        {

            IWebElement logo = driver.FindElement(By.ClassName("logo"));
            if (logo.Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }*/
        [Test]

        public void SearchItem()
        {
            IWebElement searchItem = driver.FindElement(By.Id("search_query_top"));
            if (searchItem.Displayed && searchItem.Enabled)
            {
                searchItem.SendKeys("faded");

                IWebElement searchButton = driver.FindElement(By.Name("submit_search"));
                if (searchButton.Displayed && searchButton.Enabled)
                {
                    searchButton.Click();
                }
            }
            System.Threading.Thread.Sleep(2000);

            IWebElement searchedFaded = driver.FindElement(By.XPath("//div[@class='right-block']/h5/a[@class='product-name']"));
            if (searchedFaded.Displayed && searchedFaded.Enabled)
            {
                searchedFaded.Click();
            }
            System.Threading.Thread.Sleep(2000);

            IWebElement detailsOfProducts = driver.FindElement(By.Id("quantity_wanted"));
            if (detailsOfProducts.Displayed && detailsOfProducts.Enabled)
            {
                detailsOfProducts.Clear();
                detailsOfProducts.SendKeys("2");
            }

            IWebElement detailsOfSize = driver.FindElement(By.Name("group_1"));
            wait.Until(EC.ElementExists(By.XPath("//option[@value='3']")));

            if (detailsOfSize.Enabled)
            {
                SelectElement size = new SelectElement(detailsOfSize);
                size.SelectByText("L");
                
            }
            IWebElement color = driver.FindElement(By.Name("Blue"));
            if (color.Displayed && color.Enabled)
            {
                color.Click();

            }
            IWebElement addToCartBUtton = driver.FindElement(By.Name("Submit"));
            if (addToCartBUtton.Displayed && addToCartBUtton.Enabled)
            {
                addToCartBUtton.Click();
               
            }
            System.Threading.Thread.Sleep(3000);


            IWebElement successfullAdd = driver.FindElement(By.ClassName("exclusive"));
            if (successfullAdd.Displayed && successfullAdd.Enabled)
            {
                IWebElement countinueButton = driver.FindElement(By.LinkText("Continue shopping"));
                if(countinueButton.Displayed && countinueButton.Enabled)
                {
                    countinueButton.Click();
                }

            }



        }
        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
