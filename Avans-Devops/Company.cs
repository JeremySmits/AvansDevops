using System.Collections.Generic;
namespace Avans_Devops
{
	public class Company
		{
			public string Name { get; set; }
			public string Logo { get; set; }

			public Company(string Name, string Logo)
				{
					this.Name = Name;
					this.Logo = Logo;
				}
		}
}

