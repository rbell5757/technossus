package navigationdrawer;


public class Sample
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NavigationDrawer.Sample, NavigationDrawer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Sample.class, __md_methods);
	}


	public Sample () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Sample.class)
			mono.android.TypeManager.Activate ("NavigationDrawer.Sample, NavigationDrawer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Sample (int p0, int p1, android.content.Intent p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Sample.class)
			mono.android.TypeManager.Activate ("NavigationDrawer.Sample, NavigationDrawer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:Android.Content.Intent, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
