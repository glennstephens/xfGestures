using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using Xamarin.Forms;
using XFGesturedControlDemo;
using XFGesturedControlDemo.iOS;

[assembly: ExportRenderer (typeof (GesturedFrame), typeof (GesturedFrameRenderer))]

namespace XFGesturedControlDemo.iOS
{

	public class GesturedFrameRenderer : FrameRenderer
	{
		public GesturedFrameRenderer () : base()
		{
			
		}

		GesturedFrame _frame;

		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Frame> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement != null) {
				_frame = e.NewElement as GesturedFrame;

				if (_frame.HasSwipeRightToLeft)
					NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _frame.DoSwipeRightToLeft ()) { Direction = UISwipeGestureRecognizerDirection.Left });

				if (_frame.HasSwipeLeftToRight)
					NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _frame.DoSwipeLeftToRight ()) { Direction = UISwipeGestureRecognizerDirection.Right });

				if (_frame.HasSwipeBottomToTop)
					NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _frame.DoSwipeBottomToTop ()) { Direction = UISwipeGestureRecognizerDirection.Up });

				if (_frame.HasSwipeTopToBottom)
					NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _frame.DoSwipeTopToBottom ()) { Direction = UISwipeGestureRecognizerDirection.Down });

				if (_frame.HasTap)
					NativeView.AddGestureRecognizer (new UITapGestureRecognizer (g => _frame.DoTap ()) { NumberOfTapsRequired = 1 });

				if (_frame.HasLongTap)
					NativeView.AddGestureRecognizer (new UILongPressGestureRecognizer (g => _frame.DoLongTap ()));
			}
		}
	}
}
