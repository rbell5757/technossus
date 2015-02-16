using System;
using System.Collections.Generic;

namespace tech
{
	public class employee
	{
		public long Id { get; set; }
		public string photo{ get; set; }
		public string name{ get; set; }
		public string available{get;set;}

		public employee(long id, string photo,string name,string available)
		{
			this.Id = id;
			this.photo = photo;
			this.name = name;
			this.available = available;
		}

	}
}

