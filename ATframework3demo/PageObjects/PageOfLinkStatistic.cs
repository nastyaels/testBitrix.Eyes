using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;

namespace atFrameWork2.PageObjects
{
    internal class PageOfLinkStatistic
    {
        internal string CheckStatisticOfLink()
        {
            //запоминаем статистику
            var followsFourHours = new WebItem("//tr[@class='main-grid-row main-grid-row-body']//td[@class='main-grid-cell main-grid-cell-left']//span[@class='main-grid-cell-content']", "");
            followsFourHours.WaitElementDisplayed();
            string follows = followsFourHours.GetAttribute("innerText");
            //вернемся на домашнюю страницу
            var grid = new WebItem("//img[@class='logo']", "Переход в грид по бизнесам");
            grid.WaitElementDisplayed();
            grid.Click();
            return follows;

        }
        public LeftMenu LeftMenu => new LeftMenu();

        internal PageOfLinkStatistic ClickOnLink()
        {
            var link = new WebItem("//a[contains(@href,'//dev.bx')]", "Переход по реферальной ссылке");
            link.Click();
            link.WaitWhileElementDisplayed();
            DriverActions.Back();
            link.WaitWhileElementDisplayed();
            link.WaitWhileElementDisplayed();
            return new PageOfLinkStatistic();
        }

        internal PageOfLinkStatistic OpenSettings()
        {

            //клик в настройки
            var buttonSettings = new WebItem("//span[@class='main-grid-interface-settings-icon']", "Кнопка настроек таблицы");
            buttonSettings.Click();
            buttonSettings.WaitElementDisplayed();
            return new PageOfLinkStatistic();
        }

        internal PageOfLinkStatistic UnsetAllSettings()
        {

            //убираем все чекбоксы
            var unsetAll = new WebItem("//span[@class='main-grid-settings-window-select-link main-grid-settings-window-unselect-all']",
                    "Отменить все столбцы таблицы");
            unsetAll.Click();
            unsetAll.WaitElementDisplayed();
            return new PageOfLinkStatistic();
        }

        internal PageOfLinkStatistic SetCheckBoxFourHours()
        {
            //ставим за 4 часа
            var checkBoxVisits4Hours = new WebItem("//input[@id='VISIT_4_HOUR-checkbox']", "Чекбокс переходов за 4 часа");
            checkBoxVisits4Hours.Click();
            checkBoxVisits4Hours.WaitWhileElementDisplayed();
            return new PageOfLinkStatistic();
        }

        internal PageOfLinkStatistic AcceptSettings()
        {
            //сохраняем
            var buttonSetSettings = new WebItem("//span[@id='stat_grid_FOLLOW-grid-settings-apply-button']", "Кнопка применить настройки");
            buttonSetSettings.Click();
            buttonSetSettings.WaitWhileElementDisplayed();
            return new PageOfLinkStatistic();
        }
    }
}