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
	public class PeopleFragment:Fragment
	{

		public const string ARG_NUMBER = "id_number";

		public PeopleFragment ()
		{
			// Empty constructor required for fragment subclasses
		}

		public static Fragment NewInstance (int position)
		{
			Fragment fragment = new PeopleFragment();
			Bundle args = new Bundle ();
			args.PutInt (PeopleFragment.ARG_NUMBER, position);
			fragment.Arguments = args;
			return fragment;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState)
		{
			View rootView = inflater.Inflate (Resource.Layout.people, container, false);
			ListView employeelist;
			List<employee> allemployee = new List<employee> ()
			{
				new employee(0,null,"Jone","2014/3/2"), new employee(0,null,"James","2014/4/6"),new employee(0,null,"Kate","2015/3/1"),
				new employee(0,null,"Kate","2015/3/1"),new employee(0,null,"Kate","2015/3/1"),new employee(0,null,"Kate","2015/3/1"),new employee(0,null,"Kate","2015/3/1")		};
			PeopleAdapter PeopleAdapter;
			employeelist = rootView.FindViewById<ListView> (Resource.Id.employeelist);
			PeopleAdapter = new PeopleAdapter (this.Activity, allemployee);
			employeelist.Adapter = PeopleAdapter;

			return rootView;
		}

	}
}

