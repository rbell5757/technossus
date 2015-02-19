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
using Android.Provider;

namespace NavigationDrawer
{
	public class ClientAdapter:BaseAdapter
	{
		private List<client> _allclient;
		private Activity _activity;


		public ClientAdapter(Activity a,List<client> data)
		{
			_activity = a;
			_allclient = data;
		}


		public override int Count {
			get {
				return _allclient.Count;
			}
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
		}

		public override long GetItemId (int position)
		{
			return _allclient [position].id;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? _activity.LayoutInflater.Inflate (Resource.Layout.ClientLayout, parent, false);
			var name = view.FindViewById<TextView> (Resource.Id.name);
			var contactName = view.FindViewById<TextView> (Resource.Id.contactName);
			var contactEmail = view.FindViewById<TextView> (Resource.Id.contactEmail);
			var contactImage = view.FindViewById<ImageView> (Resource.Id.picture);

			name.Text = _allclient [position].name;
			contactName.Text = "Contact: "+ _allclient [position].contactName;
			contactEmail.Text = "Email: " +_allclient [position].contactEmail;

			if (_allclient [position].photo == null) {
	
				contactImage = view.FindViewById<ImageView> (Resource.Id.picture);
				contactImage.SetImageResource (Resource.Drawable.contactImage);
	
			} else {
				//not sure about this part
	
				var contactUri = ContentUris.WithAppendedId (ContactsContract.Contacts.ContentUri, _allclient [position].id);
				var contactPhotoUri = Android.Net.Uri.WithAppendedPath (contactUri, Contacts.Photos.ContentDirectory);
	
				contactImage.SetImageURI (contactPhotoUri);
		}
		return view;
	}
}
}
	