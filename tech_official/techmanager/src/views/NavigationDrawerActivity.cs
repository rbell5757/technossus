using System;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

//Ambiguities
using Fragment = Android.App.Fragment;
using System.Collections.Generic;

namespace NavigationDrawer
{
	[Activity (Label = "@string/app_name", Icon = "@drawable/ic_launcher")]
	public class NavigationDrawerActivity : Activity, MenuAdapter.OnItemClickListener
	{
		private DrawerLayout mDrawerLayout;
		private RecyclerView mDrawerList;
		private ActionBarDrawerToggle mDrawerToggle;

		private string mDrawerTitle;
		private String[] mMenuTitles;

		protected override void OnCreate (Bundle savedInstanceState)
		{

			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_navigation_drawer);

			mDrawerTitle = this.Title;
			mMenuTitles = this.Resources.GetStringArray (Resource.Array.planets_array);
			mDrawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			mDrawerList = FindViewById<RecyclerView> (Resource.Id.left_drawer);

			// set a custom shadow that overlays the main content when the drawer opens
			mDrawerLayout.SetDrawerShadow (Resource.Drawable.drawer_shadow, GravityCompat.Start);
			// improve performance by indicating the list if fixed size.
			mDrawerList.HasFixedSize = true;
			mDrawerList.SetLayoutManager (new LinearLayoutManager (this));

			// set up the drawer's list view with items and click listener
			mDrawerList.SetAdapter (new MenuAdapter (mMenuTitles, this));
			// enable ActionBar app icon to behave as action to toggle nav drawer
			this.ActionBar.SetDisplayHomeAsUpEnabled (true);
			this.ActionBar.SetHomeButtonEnabled (true);

			// ActionBarDrawerToggle ties together the the proper interactions
			// between the sliding drawer and the action bar app icon

			mDrawerToggle = new MyActionBarDrawerToggle (this, mDrawerLayout,
				Resource.Drawable.ic_drawer, 
				Resource.String.drawer_open, 
				Resource.String.drawer_close);

			mDrawerLayout.SetDrawerListener (mDrawerToggle);
			if (savedInstanceState == null) //first launch
				selectItem (0);

		}

		internal class MyActionBarDrawerToggle : ActionBarDrawerToggle
		{
			NavigationDrawerActivity owner;

			public MyActionBarDrawerToggle (NavigationDrawerActivity activity, DrawerLayout layout, int imgRes, int openRes, int closeRes)
				: base (activity, layout, imgRes, openRes, closeRes)
			{
				owner = activity;
			}

			public override void OnDrawerClosed (View drawerView)
			{
				owner.ActionBar.Title = owner.Title;
				owner.InvalidateOptionsMenu ();
			}

			public override void OnDrawerOpened (View drawerView)
			{
				owner.ActionBar.Title = owner.mDrawerTitle;
				owner.InvalidateOptionsMenu ();
			}
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			// Inflate the menu; this adds items to the action bar if it is present.
			this.MenuInflater.Inflate (Resource.Menu.navigation_drawer, menu);
			return true;
		}

		/* Called whenever we call invalidateOptionsMenu() */
		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			// If the nav drawer is open, hide action items related to the content view
			bool drawerOpen = mDrawerLayout.IsDrawerOpen (mDrawerList);
			menu.FindItem (Resource.Id.action_websearch).SetVisible (!drawerOpen);
			return base.OnPrepareOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			// The action bar home/up action should open or close the drawer.
			// ActionBarDrawerToggle will take care of this.
			if (mDrawerToggle.OnOptionsItemSelected (item)) {
				return true;
			}
			// Handle action buttons
			switch (item.ItemId) {
			case Resource.Id.action_websearch:
				// create intent to perform web search
				Intent intent = new Intent (Intent.ActionWebSearch);
				intent.PutExtra (SearchManager.Query, this.ActionBar.Title);



				// catch event that there's no activity to handle intent
				if (intent.ResolveActivity (this.PackageManager) != null) {
					StartActivity (intent);
				} else {
					Toast.MakeText (this, Resource.String.app_not_available, ToastLength.Long).Show ();
				}
				return true;
			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		/* The click listener for RecyclerView in the navigation drawer */
		public void OnClick (View view, int position)
		{
			selectItem (position);
		}

		private void selectItem (int position)
		{
			switch (position) {
			case 0: // Project 1
				break;
			case 1: // Project 2
				break;
			case 2: // Project 3
				break;
			case 3: // Project 4
				break;
			case 4: // People Screen
				// update the main content by replacing fragments
				var peopleFragment = PeopleFragment.NewInstance (position);

				var peopleFragmentManager = this.FragmentManager;
				var peopleFt = peopleFragmentManager.BeginTransaction ();
				peopleFt.Replace (Resource.Id.content_frame, peopleFragment);
				peopleFt.Commit ();

				// update selected item title, then close the drawer
				Title = mMenuTitles [position];
				mDrawerLayout.CloseDrawer (mDrawerList);

				break;
			case 5: // Client Screen
				// update the main content by replacing fragments
				var clientFragment = ClientFragment.NewInstance (position);

				var clientFragmentManager = this.FragmentManager;
				var clientFt = clientFragmentManager.BeginTransaction ();
				clientFt.Replace (Resource.Id.content_frame, clientFragment);
				clientFt.Commit ();

				// update selected item title, then close the drawer
				Title = mMenuTitles [position];
				mDrawerLayout.CloseDrawer (mDrawerList);

				break;
			case 6: // Project Screen
				var projectFragment = ProjectFragment.NewInstance (position);

				var projectFragmentManager = this.FragmentManager;
				var projectFt = projectFragmentManager.BeginTransaction ();
				projectFt.Replace (Resource.Id.content_frame, projectFragment);
				projectFt.Commit ();

				// update selected item title, then close the drawer
				Title = mMenuTitles [position];
				mDrawerLayout.CloseDrawer (mDrawerList);

				break;
			}
		}

		private void SetTitle (string title)
		{
			this.Title = title;
			this.ActionBar.Title = title;
		}

		protected override void OnTitleChanged (Java.Lang.ICharSequence title, Android.Graphics.Color color)
		{
			//base.OnTitleChanged (title, color);
			this.ActionBar.Title = title.ToString ();
		}


		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			// Sync the toggle state after onRestoreInstanceState has occurred.
			mDrawerToggle.SyncState ();
		}

		public override void OnConfigurationChanged (Configuration newConfig)
		{
			base.OnConfigurationChanged (newConfig);
			// Pass any configuration change to the drawer toggls
			mDrawerToggle.OnConfigurationChanged (newConfig);
		}


	}
}


