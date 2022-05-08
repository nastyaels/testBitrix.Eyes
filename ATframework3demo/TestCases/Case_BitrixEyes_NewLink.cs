using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_NewLink : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Создание короткой ссылки", homePage => CreateLink(homePage)));
			return caseCollection;
		}

		void CreateLink(PortalHomePage homePage)
        {
			
			string link = "https://ru.wikipedia.org/wiki/Заглавная_страница";
			string nameOfLink = DateTime.Now.ToString();
			//перейти в бизнес с id =
			//открыть страницу Генерация ссылок
			//ввести название
			//ввести ссылку
			//нажать создать
			//проверить создалась ли ссылка
			bool isCreated =
			homePage
				.ClickOpenBusiness()
				.LeftMenu
				.OpenGenerationLinks()
				.AddNameLink(nameOfLink)
				.AddLink(link)
				.ClickCreateLink()
				.isCreatedLink(nameOfLink);
			if (!isCreated)
				Log.Error("Ссылка не создалась, а должна была создаться");
		}
	}
}

