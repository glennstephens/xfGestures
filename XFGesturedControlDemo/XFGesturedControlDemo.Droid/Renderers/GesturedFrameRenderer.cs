using System;
using Android.Views;
using XFGesturedControlDemo;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFGesturedControlDemo.Droid;

[assembly: ExportRenderer (typeof (GesturedFrame), typeof (GesturedFrameRenderer))]

namespace XFGesturedControlDemo.Droid
{
	public class GesturedFrameRenderer : FrameRenderer
	{
		public GesturedFrameRenderer () : base()
		{
			
		}

		GestureDetector _gestureDetector;

		GesturedFrame _frame;

		protected override void OnElementChanged (ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged (e);

			_frame = e.NewElement as GesturedFrame;
			_gestureDetector = new GestureDetector (new InternalGestureCapture (_frame));

			this.ChildViewAdded += (object sender, ChildViewAddedEventArgs e2) => {
				e2.Child.Touch += (object sender2, TouchEventArgs e3) => _gestureDetector.OnTouchEvent (e3.Event);
			};
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			base.OnTouchEvent (e);

			_gestureDetector.OnTouchEvent(e);

			return true;
		}
	}
}
