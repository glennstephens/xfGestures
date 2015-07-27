using System;
using Android.Views;
using XFGesturedControlDemo;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFGesturedControlDemo.Droid;

[assembly: ExportRenderer (typeof (GesturedContentPage), typeof (GesturedPageRenderer))]

namespace XFGesturedControlDemo.Droid
{
	public class GesturedPageRenderer : PageRenderer
	{
		public GesturedPageRenderer () : base()
		{

		}

		GestureDetector _gestureDetector;

		GesturedContentPage _page;

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);

			_page = e.NewElement as GesturedContentPage;
			_gestureDetector = new GestureDetector (new InternalGestureCapture (_page));
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			base.OnTouchEvent (e);

			_gestureDetector.OnTouchEvent(e);

			return true;
		}
	}
}

