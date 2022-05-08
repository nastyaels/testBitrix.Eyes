using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_SettingsTableVisits : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Настройки таблицы посещений - отображение только url, переходов всего и среднее время", homePage => SettingsTable(homePage)));
			return caseCollection;
		}

		void SettingsTable(PortalHomePage homePage)
		{
			//подготовка к кейсу - создать бизнес и запомнить его расположение
			string nameOfBusiness = DateTime.Now.ToString();

			int count =
				homePage
				.AddNameOfBusiness(nameOfBusiness)
				.ClickCreateBusinessButton()
				.FindBusinessInContainer(nameOfBusiness);
			//ставим все чекбоксы в настройках
			homePage
				.ClickOpenBusiness(count)
				.ClickSettings()
				.ChooseAllColumns()
				.ClickSetSettings()
				.logo();

			//перейти в бизнес с id = 
			//нажать шестеренку
			//убрать чек-бокс посещений за 4 часа
			//нажать применить
			//проверка
			bool isSet =
			homePage
				.ClickOpenBusiness(count)
                .ClickSettings()
                .ClickCheckboxVisits4Hours()
                .ClickSetSettings()
                .isSet4HoursCheckBox();
			if (!isSet)
				Log.Error("Переходы за 4 часа отображаются, а не должны");
		}
	}
}

