using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_FilterOfTableLinks: CaseCollectionBuilder
	{
		
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Применение фильтров для таблицы на странице переходов", homePage => Filter(homePage)));
			return caseCollection;
		}

		void Filter(PortalHomePage homePage)
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
			//создать еще ссылку и перейти по ней
			//сбросить все настройки фильтра для дальнейшей работы с ним
			string nameOfLink = DateTime.Now.ToString();
			string link = "https://ru.wikipedia.org/wiki/Заглавная_страница";
			string nameOfLink1 = DateTime.Now.ToString()+"new";

			homePage
				.ClickOpenBusiness(countBusiness)
				.LeftMenu
				.OpenGenerationLinks()
				.AddNameLink(nameOfLink)
				.AddLink(link)
				.ClickCreateLink()
				.GoToShortLink(nameOfLink)
				.AddNameLink(nameOfLink1)
				.AddLink(link)
				.ClickCreateLink()
				.GoToShortLink(nameOfLink1)
				.LeftMenu
				.OpenStatisticLinks()
				.ClickFilter()
				.ResetFieldsOfFilter()
				.ResetFilter()
				.logo();

			//открыть бизнес
			//перейти на страницу статистики переходов
			//открыть фильтр
			//выбрать тэг ввести имя первой ссылки
			//проверить отображается ли только нужная ссылка
			bool isSearch = 
			homePage
				.ClickOpenBusiness(countBusiness)
				.LeftMenu
				.OpenStatisticLinks()
				.ClickFilter()
				.AddFieldOfFilter()
				.AddTAGField()
				.SearchTAG(nameOfLink1)
				.CheckIsTAGWork(nameOfLink1);
			if (!isSearch)
				Log.Error("Ссылка содержащая такое имя не отображается первой в списке, значит фильтр по TAG не сработал");

		
		}
	}
}

