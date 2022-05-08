using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;


namespace ATframework3demo.TestCases
{
    public class Case_BitrixEyes_FollowingLinksStatistic : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Изменения статистики переходов по определенной ссылке",
                    homePage => CheckStatisticLinks(homePage)));
            return caseCollection;
        }

        void CheckStatisticLinks(PortalHomePage homePage)
        {

            //подготовка к тесту
            //создать бизнес
            //запомнить его расположение
            string nameOfBusiness = DateTime.Now.ToString();

            int countBusiness =
                homePage
                .AddNameOfBusiness(nameOfBusiness)
                .ClickCreateBusinessButton()
                .FindBusinessInContainer(nameOfBusiness);

            //перейти в бизнес
            //создать ссылку и перейти по ней
            //сбросить все настройки фильтра для дальнейшей работы с ним
            string nameOfLink = DateTime.Now.ToString();
            string link = "https://ru.wikipedia.org/wiki/Заглавная_страница";
            homePage
                .ClickOpenBusiness(countBusiness)
                .LeftMenu
                .OpenGenerationLinks()
                .AddNameLink(nameOfLink)
                .AddLink(link)
                .ClickCreateLink()
                .GoToShortLink(nameOfLink)
                .logo();

            //открыть нужный бизнес
            //открыть страницу статистики переходов
            //Настроить таблицу на отображение только последних 4 часов переходов
            //Найдем по тэгу ссылку
            //запомнить посещения нужной ссылки

            string follows =
            homePage
                .ClickOpenBusiness(countBusiness)
                .LeftMenu
                .OpenStatisticLinks()
                .ClickSettings()
                .UnsetAllSettings()
                .SetSettingsFourHours()
                .ClickSetSettings()
                .ClickFilter()
                .ResetFilter()
                .ClickFilter()
                .ResetFieldsOfFilter()
                .AddFieldOfFilter()
                .AddTAGField()
                .SearchTAG(nameOfLink)
                .CheckStatisticOfLink();

            //открыть нужный бизнес
            //открыть страницу статистики переходов
            //вернуть все к дефолтным настройкам, чтобы нажать на тэг
            //открыть статистику нужной ссылки
            //перейти по ссылке  и вернуться назад
            //открыть страницу переходов
            //в настройках поставить последние 4 часа
            //запомнить новую статистику

            string newFollows =
                homePage
                    .ClickOpenBusiness(countBusiness)
                    .LeftMenu
                    .OpenStatisticLinks()
                    .ClickSettings()
                    .DefaultSettingsLink()
                    .AcceptDefaultSettingsLink()
                    .OpenStatisticOfLink(nameOfLink)
                    .ClickOnLink()
                    .OpenSettings()
                    .UnsetAllSettings()
                    .SetCheckBoxFourHours()
                    .AcceptSettings()
                    .CheckStatisticOfLink();

            //сравнить переходы до и после посещения нужной ссылки
            if (follows.Equals(newFollows))
                Log.Error("Статистика не обновилась, а должна была");
        }

    }
}

