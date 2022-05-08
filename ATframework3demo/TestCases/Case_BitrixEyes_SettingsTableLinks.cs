using System;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_SettingsTableLinks : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Настройки таблицы переходов - отображение только tag и переходов всего", homePage => SettingsTable(homePage)));
			return caseCollection;
		}

		void SettingsTable(PortalHomePage homePage)
		{
			//подготовка к кейсу
			//создаем бизнес
			//определяем его положение в сетке контейнера бизнесов
			
			string nameOfBusiness = DateTime.Now.ToString();

			int count =
				homePage
				.AddNameOfBusiness(nameOfBusiness)
				.ClickCreateBusinessButton()
				.FindBusinessInContainer(nameOfBusiness);

			//ставим все чекбоксы в настройках
			homePage
				.ClickOpenBusiness(count)
				.LeftMenu
                .OpenStatisticLinks()
                .ClickSettings()
                .ChooseAllColumns()
                .ClickSetSettings()
                .logo();
  
            //перейти в бизнес с id =
            //перейти на страницу статистика переходов
            //нажать шестеренку
            //убрать чек-бокс посещений за 4 часа
            //нажать применить
            //проверка
            bool isSet =
			homePage
				.ClickOpenBusiness(count)
				.LeftMenu
				.OpenStatisticLinks()
				.ClickSettings()
				.SetSettingsFourHours()
				.ClickSetSettings()
				.isSetCheckBox4Hours();
			if (!isSet)
				Log.Error("Переходы за 4 часа отображаются, а не должны");


		}
	}
}

