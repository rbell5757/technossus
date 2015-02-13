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
	[Activity (Label = "Live Feed")]			
	public class livefeed : Activity
	{
		DrawerLayout DrawerLayout;
		List<string> LeftItem = new List<string> ();
		ArrayAdapter LeftAdapter;
		ListView LeftDrawer;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			SetContentView (Resource.Layout.livefeed);
			// Create your application here
			DrawerLayout = FindViewById<DrawerLayout> (Resource.Id.livefeedmain);
			LeftDrawer = FindViewById<ListView> (Resource.Id.ToolBar2);

			LeftItem.Add ("project 1");
			LeftItem.Add ("project 2");
			LeftItem.Add ("project 3");
			LeftItem.Add ("project 4");
			LeftItem.Add ("projects");
			LeftItem.Add ("clients");
			LeftItem.Add ("people");


			LeftDrawer.Adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, LeftItem);
			LeftDrawer.ItemClick += DrawerListOnItemClick;

		}

		private void DrawerListOnItemClick(object Sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
		{
			switch (itemClickEventArgs.Position) 
			{
			case 0: // Project 1
				break;
			case 1: // Project 2
				break;
			case 2: // Project 3
				break;
			case 3: // Project 4
				break;
			case 4: // Projects Screen
				break;
			case 5: // Client Screen
				Intent intent = new Intent (this, typeof(client));
				this.StartActivity (intent);
				break;
			case 6: // People Screen
				break;


			}
		}
	}
}

