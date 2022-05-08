using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    internal class StatisticOfLinksPage
    {
        public LeftMenu LeftMenu => new LeftMenu();

        internal StatisticOfLinksPage MarkCheckBoxUnique()
        {
            //отметить чекбокс - уникальные
            var checkBoxUnique = new WebItem("//span[@class='checkbox-ios-switch']", "Чекбокс уникальные пользователи");
            checkBoxUnique.Click();
            checkBoxUnique.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal bool IsMarkedCheckBoxUnique()
        {
            //проверить стоит ли чекбокс
            var checkBoxUnique = new WebItem("//input[@name='unique_only']", "Чекбокс уникальные пользователи");
            bool isChecked = checkBoxUnique.Checked();
            return isChecked;
        }

        internal bool Checked4HoursCheckBox()
        {
            //проверяем стоит ли чекбокс
            var checkBoxVisits4Hours = new WebItem("//input[@id='VISIT_4_HOUR-checkbox']", "Чекбокс переходов за 4 часа");
            bool isChecked = checkBoxVisits4Hours.Checked();
            //выходим из настроек
            var cancelSettings = new WebItem("//span[@id='stat_grid_FOLLOW-grid-settings-cancel-button']", "Кнопка закрыть настройки");
            cancelSettings.Click();
            //возвращаемся в грид по бизнесам
            logo();
            //возвращаем стоит ли чекбокс
            return isChecked ;
        }

        internal StatisticOfLinksPage ChooseAllColumns()
        {
            //выбрать все столбцы таблицы
            var chooseAll = new WebItem("//span[@class='main-grid-settings-window-select-link main-grid-settings-window-select-all']", "Кнопка выбрать все");
            chooseAll.Click();
            return new StatisticOfLinksPage();
        }

        internal StatisticOfLinksPage UnsetAllSettings()
        {
            //убираем все чекбоксы
            var unsetAll = new WebItem("//span[@class='main-grid-settings-window-select-link main-grid-settings-window-unselect-all']",
                    "Отменить все столбцы таблицы");
            unsetAll.Click();
            unsetAll.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal bool CheckIsTAGWork(string name)
        {
            var container = new WebItem("//tr[@class= 'main-grid-row main-grid-row-body']", "Первая строка таблицы");
            return container.isDisplayedElementIn("//a[contains(text(),'"+name+"')]");
        }

        internal StatisticOfLinksPage ResetFieldsOfFilter()
        {
            //поля по умолчанию
            var resetFields = new WebItem("//span[@class='main-ui-filter-field-restore-items']", "Поля по умолчанию");
            resetFields.Click();
            resetFields.WaitWhileElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal string CheckStatisticOfLink()
        {
            //запоминаем статистику
            var followsFourHours = new WebItem("//tr[@class='main-grid-row main-grid-row-body']//td[@class='main-grid-cell main-grid-cell-left']//span[@class='main-grid-cell-content']", "");
            followsFourHours.WaitElementDisplayed();
            string follows = followsFourHours.GetAttribute("innerText");
            //вернемся на домашнюю страницу
            logo();
            return follows;
        }

        internal StatisticOfLinksPage ClickFilter()
        {
            //кликнуть в фильтр
            var filterOfTable = new WebItem("//div[@class='statistic-grid-container']//div[@id='stat_grid_FOLLOW_search_container']",
                    "Фильтр");
            filterOfTable.Click();
            filterOfTable.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }
        internal StatisticOfLinksPage ResetFilter()
        {
            //сбрасываем фильтр
            var resetFilter = new WebItem("//span[@class='ui-btn ui-btn-light-border main-ui-filter-field-button main-ui-filter-reset']", "Сбросить");
            resetFilter.Click();
            resetFilter.WaitWhileElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal StatisticOfLinksPage AddFieldOfFilter()
        {
            //добавить поле 
            var addField = new WebItem("//span[@class='main-ui-filter-field-add-item']", "Добавить поле");
            addField.Click();
            addField.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal StatisticOfLinksPage AddTAGField()
        {
            //ставим только тег
            var checkBox = new WebItem("//div[@data-id='field_TAG']", "Чекбокс тэга");
            checkBox.Click();
            checkBox.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal StatisticOfLinksPage SearchTAG(string linkName)
        {
            //ищем по тэгу ссылку, чтобы отображалась в таблице статистика только по ней
            var searchTAG = new WebItem("//input[@class='main-ui-control main-ui-control-string']", "Поиск по тэгу");
            searchTAG.SendKeys(linkName);
            //жмем найти
            var searchButton = new WebItem("//button[@class='ui-btn ui-btn-primary ui-btn-icon-search main-ui-filter-field-button main-ui-filter-find']", "Кнопка найти");
            searchButton.Click();
            return new StatisticOfLinksPage();
        }


        internal StatisticOfLinksPage SetSettingsFourHours()
        {
            //ставим за 4 часа
            var checkBoxVisits4Hours = new WebItem("//input[@id='VISIT_4_HOUR-checkbox']", "Чекбокс переходов за 4 часа");
            checkBoxVisits4Hours.Click();
            checkBoxVisits4Hours.WaitWhileElementDisplayed();
            return new StatisticOfLinksPage();
        }

        internal StatisticOfLinksPage DefaultSettingsLink()
        {
            //настройки по умолчанию
            var defaultSettings = new WebItem("//span[@id='stat_grid_FOLLOW-grid-settings-reset-button']", "Вернуть по умолчанию настройки");
            defaultSettings.Click();
            return new StatisticOfLinksPage();
        }
        internal StatisticOfLinksPage AcceptDefaultSettingsLink()
        {
            //принять дефолтные настройки
            var accept = new WebItem("//span[@id='stat_grid_FOLLOW-confirm-dialog-apply-button']", "Подтвердить настройки");
            accept.Click();
            return new StatisticOfLinksPage();
        }


        internal PageOfLinkStatistic OpenStatisticOfLink(string linkName)
        {
            //открыть страницу статистики по конкретной ссылке с таким именем
            var link = new WebItem("//a[contains(text(),'" + linkName + "')]", "");
            link.Click();
            link.WaitWhileElementDisplayed();
            return new PageOfLinkStatistic();
        }

        internal PortalHomePage logo()
        {
            var grid = new WebItem("//div[@class='logo-container']", "Переход в грид по бизнесам");
            grid.Click();
            return new PortalHomePage();
        }

        internal bool isSetCheckBox4Hours()
        {
            var gridContainer = new WebItem("//div[@class='main-grid-container']", "Таблица");
            var textOfColumn = "Переходов за 4 часа";
            if (gridContainer.isDisplayedElementIn("//span[@class='main-grid-head-title'][contains(text(),'"+textOfColumn+"')]"))
            {
                gridContainer.WaitElementDisplayed();
                return false;
            }
            return true;
        }

        internal StatisticOfLinksPage ClickSetSettings()
        {
            //применить настройки
            var buttonSetSettings = new WebItem("//span[@id='stat_grid_FOLLOW-grid-settings-apply-button']", "Кнопка применить настройки");
            buttonSetSettings.Click();
            buttonSetSettings.WaitWhileElementDisplayed();
            return new StatisticOfLinksPage();
        }
 

        internal StatisticOfLinksPage ClickSettings()
        {
            //нажать на кнопку настроек страницы
            var buttonSettings = new WebItem("//span[@class='main-grid-interface-settings-icon']", "Кнопка настроек таблицы");
            buttonSettings.Click();
            buttonSettings.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }

    }
}