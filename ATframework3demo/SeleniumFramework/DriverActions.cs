﻿using atFrameWork2.BaseFramework.LogTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.SeleniumFramework
{
    class DriverActions
    {
        public static IWebDriver GetNewDriver()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        public static void Refresh(IWebDriver driver = default)
        {
            Log.Info($"{nameof(Refresh)}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().Refresh();
        }

        public static void OpenUri(Uri uri, IWebDriver driver = default)
        {
            Log.Info($"{nameof(OpenUri)}: {uri}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().GoToUrl(uri);
        }

        public static void SwitchToDefaultContent(IWebDriver driver = default)
        {
            Log.Info($"{nameof(SwitchToDefaultContent)}");
            driver ??= WebItem.DefaultDriver;
            driver.SwitchTo().DefaultContent();
        }

        public static void Back(IWebDriver driver = default)
        {
            Log.Info($"{nameof(Back)}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().Back();
        }

        public static void GoToUrl(string url,IWebDriver driver = default)
        {
            Log.Info($"{nameof(GoToUrl)}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().GoToUrl(url);
        }
    }
}
