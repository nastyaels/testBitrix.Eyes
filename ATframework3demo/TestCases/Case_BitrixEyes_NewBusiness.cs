
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;


namespace ATframework3demo.TestCases
{
	public class Case_BitrixEyes_NewBusiness : CaseCollectionBuilder
	{
		protected override List<TestCase> GetCases()
		{
			var caseCollection = new List<TestCase>();
			caseCollection.Add(new TestCase("Создание нового бизнеса", homePage => CreateBusiness(homePage)));
			return caseCollection;
		}
		
		void CreateBusiness(PortalHomePage homePage)
        {

			string name = DateTime.Now.ToString();//чтобы имя было уникальным возьмем текущую дату и время

			//ввести название бизнеса
			//кликнуть на кнопку "Создать"
			//проверить создался ли бизнес с таким именем

			homePage
				.AddNameOfBusiness(name)
				.ClickCreateBusinessButton();

			//есть ли карточка бизнеса с таким именем
			bool IsCreatedBusiness = homePage
				.CheckIsCreatedBusiness(name);
			if (!IsCreatedBusiness)
				Log.Error("Бизнес с именем"+name+" не был создан");
        }
		
	}
}

