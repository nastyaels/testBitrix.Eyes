using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    internal class StatisticOfVisitsPage
    {
        internal StatisticOfVisitsPage MarkUniqueCheckBox()
        {
            //отметить чекбокс уникальные
            var checkBoxUnique = new WebItem("//span[@class='checkbox-ios-switch']", "Чекбокс уникальные пользователи");
            checkBoxUnique.Click();
            checkBoxUnique.WaitElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal bool IsMarkedCheckBoxUnique()
        {
            //проверить стоит ли чекбокс уникальные
            var checkBoxUnique = new WebItem("//input[@name='unique_only']", "Чекбокс уникальные пользователи");
            bool isChecked = checkBoxUnique.Checked();
            return isChecked;
        }
        internal StatisticOfVisitsPage ChooseAllColumns()
        {
            //выбрать все столбцы таблицы
            var chooseAll = new WebItem("//span[@class='main-grid-settings-window-select-link main-grid-settings-window-select-all']", "Кнопка выбрать все");
            chooseAll.Click();
            return new StatisticOfVisitsPage();
        }
        internal bool Checked4HoursCheckBoxAndBackToBusinesses()
        {
            //проверяем стоит ли чекбокс
            var checkBoxVisits4Hours = new WebItem("//input[@id='VISIT_4_HOUR-checkbox']", "Чекбокс переходов за 4 часа");
            bool isChecked = checkBoxVisits4Hours.Checked();
            //выходим из настроек
            var cancelSettings = new WebItem("//span[@id='stat_grid_VISIT-grid-settings-cancel-button']", "Кнопка закрыть настройки");
            cancelSettings.Click();
            //возвращаемся в грид по бизнесам
            logo();
            //возвращаем стоит ли чекбокс
            return isChecked;
        }

        internal StatisticOfVisitsPage OpenSiteAndBack(string url)
        {
            //посещаем сайт и обновляем страницу
            DriverActions.GoToUrl(url);
            DriverActions.Refresh();
            //возвращаемся обратно и обнавляем страницу статистики 
            DriverActions.Back();
            DriverActions.Refresh();
            return new StatisticOfVisitsPage();
        }

        internal string GetVisitsOfSiteAndBackToBusinesses()
        {
            //запоминаем статистику
            var followsFourHours = new WebItem("//tr[@class='main-grid-row main-grid-row-body']//td[@class='main-grid-cell main-grid-cell-left']//span[@class='main-grid-cell-content']", "");
            followsFourHours.WaitElementDisplayed();
            string follows = followsFourHours.GetAttribute("innerText");
            if (follows == null)
                follows = "0";
            //вернемся на домашнюю страницу
            logo();
            return follows;
        }

        internal StatisticOfVisitsPage UnsetAllSettings()
        {
            //убираем все настройки
            var unsetAll = new WebItem("//span[@class='main-grid-settings-window-select-link main-grid-settings-window-unselect-all']",
                    "Отменить все столбцы таблицы");
            unsetAll.Click();
            unsetAll.WaitElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal StatisticOfVisitsPage ClickFilter()
        {
            //кликнуть в фильтр
            var filterOfTable = new WebItem("//div[@class='statistic-grid-container']//div[@id='stat_grid_VISIT_search_container']",
                    "Фильтр");
            filterOfTable.Click();
            filterOfTable.WaitElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal StatisticOfVisitsPage ResetFilter()
        {
            //сбрасываем фильтр
            var resetFilter = new WebItem("//span[@class='ui-btn ui-btn-light-border main-ui-filter-field-button main-ui-filter-reset']", "Сбросить");
            resetFilter.Click();
            resetFilter.WaitWhileElementDisplayed();
            return new StatisticOfVisitsPage();
        }
        internal StatisticOfVisitsPage DefaultFiledsFilter()
        {
            //поля по умолчанию
            var resetFields = new WebItem("//span[@class='main-ui-filter-field-restore-items']", "Поля по умолчанию");
            resetFields.Click();
            resetFields.WaitWhileElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal StatisticOfVisitsPage AddFiledFilter()
        {
            //добавить поле 
            var addField = new WebItem("//span[@class='main-ui-filter-field-add-item']", "Добавить поле");
            addField.Click();
            addField.WaitElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal StatisticOfVisitsPage AddUrlFieldFilter()
        {
            //ставим Url
            var urlCheckBox = new WebItem("//div[@data-id='field_URL']", "Чекбокс URL");
            urlCheckBox.Click();
            urlCheckBox.WaitElementDisplayed();
            return new StatisticOfVisitsPage();
        }
        internal StatisticOfVisitsPage SearchUrlFilter(string url)
        {
            //вводим в поиск по url страницу сайта с меткой
            var searchUrl = new WebItem("//input[@name='URL']", "Вводим в поле URL ссылку");
            searchUrl.SendKeys(url);
            return new StatisticOfVisitsPage();
        }
        internal StatisticOfVisitsPage ClickSearchFilter()
        {
            //жмем найти
            var searchButton = new WebItem("//button[@class='ui-btn ui-btn-primary ui-btn-icon-search main-ui-filter-field-button main-ui-filter-find']", "Кнопка найти");
            searchButton.Click();
            searchButton.WaitWhileElementDisplayed();
            return new StatisticOfVisitsPage();
        }
        
        internal bool isSet4HoursCheckBox()
        {
            //проверить стоит ли чекбокс посещения за 4 часа
            var gridContainer = new WebItem("//div[@class='main-grid-container']", "Таблица");
            var textOfColumn = "Посещений за 4 часа";
            if (gridContainer.isDisplayedElementIn("//span[@class='main-grid-head-title'][contains(text(),'" + textOfColumn + "')]"))
            {
                gridContainer.WaitElementDisplayed();
                return false;
            }
            return true;
        }

        internal StatisticOfVisitsPage ClickSetSettings()
        {
            //применить настройки
            var buttonSetSettings = new WebItem("//span[@id='stat_grid_VISIT-grid-settings-apply-button']", "Кнопка применить настройки");
            buttonSetSettings.Click();
            buttonSetSettings.WaitWhileElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal StatisticOfVisitsPage ClickCheckboxVisits4Hours()
        {
            //отметить чекбокс посещения за 4 часа
            var checkBoxVisits4Hours = new WebItem("//input[@id='VISIT_4_HOUR-checkbox']", "Чекбокс посещений за 4 часа");
            checkBoxVisits4Hours.Click();
            checkBoxVisits4Hours.WaitWhileElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        internal StatisticOfVisitsPage ClickSettings()
        {
            //нажать на настройки
            var buttonSettings = new WebItem("//span[@class='main-grid-interface-settings-icon']", "Кнопка настроек таблицы");
            buttonSettings.WaitElementDisplayed();
            buttonSettings.Click();
            buttonSettings.WaitElementDisplayed();
            return new StatisticOfVisitsPage();
        }

        public LeftMenu LeftMenu => new LeftMenu();

        internal PortalHomePage logo()
        {
            //перейти в грид по бизнесам
            var grid = new WebItem("//div[@class='logo-container']", "Переход в грид по бизнесам");
            grid.Click();
            return new PortalHomePage();
        }
       
    }
}