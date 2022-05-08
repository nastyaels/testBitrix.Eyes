using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalHomePage
    {
        internal PortalHomePage AddNameOfBusiness(String name)
        {
            //ввести название бизнеса
            var inputNameOfBusiness = new WebItem("//input[@name='business-name']", "Поле ввода названия бизнеса");
            inputNameOfBusiness.SendKeys(name);
            return new PortalHomePage();
        }

        internal string getFirstBusinessName()
        {
            //получаем название бизнеса
            var businessesContainer = new WebItem("//div[@class='businesses-container']","Контейнер бизнесов");
            if (businessesContainer.isDisplayedElementIn("//div[@class='card-field-with-btn card-title']"))
            {
                var firstCardBusiness = new WebItem("//div[@class='card-field-with-btn card-title']", "Карточка первого бизнеса");
                return firstCardBusiness.GetAttribute("innerText");
            }
            return null;
        }

        internal int FindBusinessInContainer(string name)
        {
            var businessesContainer = new WebItem("//div[@class='businesses-container']", "Контейнер бизнесов");
            int number = 0;
            number = businessesContainer.CountOfTheElement("//div[@class='card-field-with-btn card-title']");
            return number;
        }

        public LeftMenu LeftMenu => new LeftMenu();

        internal StatisticOfVisitsPage ClickOpenBusinessById(int idBusiness)
        {
            //клик на кнопку открыть бизнес с id 
            var buttonOpen = new WebItem("//a[@class='ui-btn ui-btn-success'][@href='/businesses/" + idBusiness + "/statistic/visit']",
                "Кнопка открыть бизнес с id:" + idBusiness);
            buttonOpen.Click();
            return new StatisticOfVisitsPage();
        }


        internal StatisticOfVisitsPage ClickOpenBusiness(int count)
        {
            //клик на кнопку открыть бизнес с id 
            var buttonOpen = new WebItem("//div[@class='business-card']["+count+"]//a[@class='ui-btn ui-btn-success']",
                "Кнопка открыть бизнес с id:" + count);
            buttonOpen.Click();
            return new StatisticOfVisitsPage();
        }
        internal StatisticOfVisitsPage ClickOpenBusiness()
        {
            //клик на кнопку открыть бизнес (откроет первый созданный)
           
            var buttonOpen = new WebItem("//a[@class='ui-btn ui-btn-success']", "Кнопка открыть бизнес");
            buttonOpen.Click();
            return new StatisticOfVisitsPage();
        }
        internal PortalHomePage DeleteBusiness()
        {
            //нажать удалить бизнес и подтвердить удаление
            var buttonDelete = new WebItem("//button[@class='delete-btn-cross']","Кнопка удаления бизнеса");
            buttonDelete.Click();
            buttonDelete.WaitWhileElementDisplayed();
            var accessDeleting = new WebItem("//div[@class='popup-window-buttons']//button[@class='ui-btn ui-btn-success']",
                    "Подтверждение удаления бизнеса");
            accessDeleting.Click();
            accessDeleting.WaitWhileElementDisplayed();
            return new PortalHomePage();
        }

        internal bool isBusinessIsDisplayed(string name)
        {
            //проверка удален ли бизнес (есть ли такой бизнес)
            var businessesContainer = new WebItem("//div[@class='businesses-container']", "Контейнер бизнесов");
            businessesContainer.WaitElementDisplayed();
            return businessesContainer.isDisplayedElementIn("//div[@class='card-field-with-btn card-title'][contains(text(),'" + name + "')]");
            
        }

        internal PortalHomePage ClickCreateBusinessButton()
        {
            //клик на кнопку создать бизнес
            var createButton = new WebItem("//button[@class='ui-btn ui-btn-success'][@name='submit']", "Кнопка создать бизнес");
            createButton.Click();
            createButton.WaitWhileElementDisplayed();
            return new PortalHomePage();
        }


        internal bool CheckIsCreatedBusiness(String name)
        {
            //проверить создан ли бизнес с таким именем
            var businessContainer = new WebItem("//div[@class='businesses-container']", "Контйенер карточек бизнесов");
            return businessContainer.isDisplayedElementIn("//div[@class='card-field-with-btn card-title'][contains(text(),'" + name + "')]");
            //var bsCard = new WebItem("//div[@class='card-field-with-btn card-title'][contains(text(),'" + name + "')]", "Карточка бизнеса");
            //string txt = bsCard.GetAttribute("innerText");
            //if (txt.Contains(name))
            //    return true;
            //return false;
        }
    }
}
