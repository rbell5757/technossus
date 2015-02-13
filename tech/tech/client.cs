// Execution Test #2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Support.V4.App;

namespace tech
{
	[Activity (Label = "Client")]			
	public class client : Activity
	{
		DrawerLayout DrawerLayout;
		List<string> LeftItem = new List<string> ();
		ArrayAdapter LeftAdapter;
		ListView LeftDrawer;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.clients);
			// Create your application here

			DrawerLayout = FindViewById<DrawerLayout> (Resource.Id.main);
			LeftDrawer = FindViewById<ListView> (Resource.Id.ToolBar);

			LeftItem.Add ("project 1");
			LeftItem.Add ("project 2");
			LeftItem.Add ("project 3");
			LeftItem.Add ("project 4");
			LeftItem.Add ("projects");
			LeftItem.Add ("clients");
			LeftItem.Add ("people");


			LeftAdapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, LeftItem);
			LeftDrawer.Adapter = LeftAdapter;

		}
	}
}

