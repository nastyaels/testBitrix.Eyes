using System;
namespace ATframework3demo.TestEntities
{
	public class BitrixEyesBusiness
	{
		public BitrixEyesBusiness(String title)
		{
			
			Title = title ?? throw new ArgumentNullException(nameof(title));
			
		}
		public string Title { get; set; }
	}
}

