using System;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
	public class LeftMenu
	{
        internal GenerationLinksPage OpenGenerationLinks()
        {
            //открыть страницу генерации бизнесов
            var buttonOpenGenerationLinksPage = new WebItem("//a[contains(text(),'Генерация ссылок')]", "Переход на страницу Генерация ссылок");
            buttonOpenGenerationLinksPage.Click();
            return new GenerationLinksPage();
        }

        internal StatisticOfLinksPage OpenStatisticLinks()
        {
            //перейти на страницу Статистики переходов
            var buttonOpenStatisticLinks = new WebItem("//a[contains(text(),'Статистика переходов')]",
                "Переход на страницу Статистика переходов");
            buttonOpenStatisticLinks.Click();
            buttonOpenStatisticLinks.WaitElementDisplayed();
            return new StatisticOfLinksPage();
        }

    }
}

