using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_UniqueTAG : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Поставить чек-бокс уникальные пользователи на странице Статистика Переходов",
					homePage => UniqueTags(homePage)));
			return caseCollection;
		}

		void UniqueTags(PortalHomePage homePage)
		{
			//подготовка к кейсу - создать бизнес и запомнить его расположение
			string nameOfBusiness = DateTime.Now.ToString();

			int count =
				homePage
				.AddNameOfBusiness(nameOfBusiness)
				.ClickCreateBusinessButton()
				.FindBusinessInContainer(nameOfBusiness);

			//открыть бизнес
			//перейти на страницу Статистика переходов
			//поставить чек-бокс
			//проверить поставлен ли чек-бокс и отображаются только уникальные
			bool isMarked = 
				homePage
				   .ClickOpenBusiness(count)
				   .LeftMenu
				   .OpenStatisticLinks()
				   .MarkCheckBoxUnique()
				   .IsMarkedCheckBoxUnique();
			if(!isMarked)
				Log.Error("Чек-бокс не поставлен, а должен быть");

		}
	}
}

