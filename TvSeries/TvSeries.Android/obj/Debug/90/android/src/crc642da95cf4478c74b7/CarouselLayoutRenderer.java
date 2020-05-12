package crc642da95cf4478c74b7;


public class CarouselLayoutRenderer
	extends crc643f46942d9dd1fff9.ScrollViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_onSizeChanged:(IIII)V:GetOnSizeChanged_IIIIHandler\n" +
			"";
		mono.android.Runtime.register ("CarouselView.Platforms.Android.CarouselLayoutRenderer, CarouselView", CarouselLayoutRenderer.class, __md_methods);
	}


	public CarouselLayoutRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CarouselLayoutRenderer.class)
			mono.android.TypeManager.Activate ("CarouselView.Platforms.Android.CarouselLayoutRenderer, CarouselView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CarouselLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CarouselLayoutRenderer.class)
			mono.android.TypeManager.Activate ("CarouselView.Platforms.Android.CarouselLayoutRenderer, CarouselView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CarouselLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CarouselLayoutRenderer.class)
			mono.android.TypeManager.Activate ("CarouselView.Platforms.Android.CarouselLayoutRenderer, CarouselView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);


	public void onSizeChanged (int p0, int p1, int p2, int p3)
	{
		n_onSizeChanged (p0, p1, p2, p3);
	}

	private native void n_onSizeChanged (int p0, int p1, int p2, int p3);

	private java.util.ArrayList refList;
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
