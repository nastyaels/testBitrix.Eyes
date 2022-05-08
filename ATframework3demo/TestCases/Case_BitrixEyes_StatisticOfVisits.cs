using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_StatisticOfVisits : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Изменения статистики посещений после посещения сайта",
					homePage => CheckStatisticVisits(homePage)));
			return caseCollection;
		}

		void CheckStatisticVisits(PortalHomePage homePage)
        {
			//страница сайта, на коротой лежит метка(файл к корне проекта, измените путь и вставьте метку своего бизнеса)
			string url = "file:///Users/anastasia/AT/autotest/ATframework3demo/test.html";

			//бизнес, который считывает метку(указать бизнес, из которого бралась метка)
			int idBusiness = 75;

			//подготовка к кейсу
			//открыть нужный бизнес
			//найти ссылку в таблице
			//поставить чтобы были только посещения за 4 часа в таблице
			//запомнить посещения нужной ссылки за 4 часа и вернуться в грид по бизнесам
			string visits =
			homePage
				.ClickOpenBusinessById(idBusiness)
				.ClickFilter()
				.ResetFilter()
				.ClickFilter()
				.DefaultFiledsFilter()
				.AddFiledFilter()
				.AddUrlFieldFilter()
				.SearchUrlFilter(url)
				.ClickSearchFilter()
				.ClickSettings()
				.UnsetAllSettings()
				.ClickCheckboxVisits4Hours()
				.ClickSetSettings()
				.GetVisitsOfSiteAndBackToBusinesses();

			//открыть бизнес
			//перейти на сайт и вернуться
			//найти ссылку в таблице
			//поставить чтобы были только посещения за 4 часа в таблице
			//запомнить посещения нужной ссылки за 4 часа и вернуться в грид по бизнесам
			string newVisits =
				homePage
				.ClickOpenBusinessById(idBusiness)
				.OpenSiteAndBack(url)
				.GetVisitsOfSiteAndBackToBusinesses();

			if (newVisits.Equals(visits))
				Log.Error("Статистика не поменялась, а должна была");

		}
	}
}

