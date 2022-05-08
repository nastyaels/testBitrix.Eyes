using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_DeleteLink : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Удаление короткой ссылки", homePage => DeleteLink(homePage)));
			return caseCollection;
		}

		void DeleteLink(PortalHomePage homePage)
		{
			//подготовка к кейсу - создать бизнес и запомнить его расположение
			string nameOfBusiness = DateTime.Now.ToString();

			int count =
				homePage
				.AddNameOfBusiness(nameOfBusiness)
				.ClickCreateBusinessButton()
				.FindBusinessInContainer(nameOfBusiness);
			string name;
			//подготовка к кейсу - добавим ссылку(если нет созданных, то будет что удалить) и запомним имя первой ссылки
			if (homePage.ClickOpenBusiness(count).LeftMenu.OpenGenerationLinks().GetNameOfFirstLink() != null)
				name = homePage
					.ClickOpenBusiness(count)
					.LeftMenu
					.OpenGenerationLinks()
					.GetNameOfFirstLink();
			else
            {
				name = homePage
				.ClickOpenBusiness(count)
				.LeftMenu
				.OpenGenerationLinks()
				.AddNameLink(DateTime.Now.ToString())
				.AddLink("https://ru.wikipedia.org/wiki/Заглавная_страница")
				.ClickCreateLink()
				.GetNameOfFirstLink();
			}
			
            //открыть бизнес с id 
            //перейти в Генерация ссылок
            //нажать на крестик нужной ссылки
            //проверить удалилась ли
            bool isDeleted = 
			homePage
				.ClickOpenBusiness(count)
				.LeftMenu
				.OpenGenerationLinks()
				.ClickDeleteLink()
				.isDeletedLink(name);
			if (!isDeleted)
				Log.Error("Ссылка не удалена, а должна была удалиться");
		}
	}
}

