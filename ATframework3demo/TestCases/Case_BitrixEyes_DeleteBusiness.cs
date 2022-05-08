using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_DeleteBusiness : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Удаление бизнеса", homePage => DeleteBusiness(homePage)));
			return caseCollection;
		}
		void DeleteBusiness(PortalHomePage homePage)
		{
			string firstBusiness=null;
			//подготовка к кейсу создадим бизнес (чтобы если бизнесов нет можно было что-то удалить) и запомним имя первого бизнеса
			if (homePage.getFirstBusinessName() != null)
				firstBusiness = homePage.getFirstBusinessName();
			else
			{
				firstBusiness = homePage
				.AddNameOfBusiness(DateTime.Now.ToString())
				.ClickCreateBusinessButton()
				.getFirstBusinessName();
			}

			//удалить первый бизнес
			homePage
				.DeleteBusiness();

			//проверить отображается ли первый бизнес
			bool isDisplayed = homePage.isBusinessIsDisplayed(firstBusiness);

			if (isDisplayed == true)
				Log.Error("Бизнес должен был удалиться, но не удалился");

		}


	}
}

