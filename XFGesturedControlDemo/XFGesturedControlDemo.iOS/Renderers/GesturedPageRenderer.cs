using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using Xamarin.Forms;
using XFGesturedControlDemo;
using XFGesturedControlDemo.iOS;

[assembly: ExportRenderer (typeof (GesturedContentPage), typeof (GesturedPageRenderer))]

namespace XFGesturedControlDemo.iOS
{
	public class GesturedPageRenderer : PageRenderer
	{
		public GesturedPageRenderer () : base()
		{
		}

		GesturedContentPage _page;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_page = this.Element as GesturedContentPage;

			if (_page.HasSwipeRightToLeft)
				NativeView.AddGestureRecognizer(new UISwipeGestureRecognizer(g => _page.DoSwipeRightToLeft ()) {Direction = UISwipeGestureRecognizerDirection.Left});

			if (_page.HasSwipeLeftToRight)
				NativeView.AddGestureRecognizer(new UISwipeGestureRecognizer(g => _page.DoSwipeLeftToRight ()) {Direction = UISwipeGestureRecognizerDirection.Right});

			if (_page.HasSwipeBottomToTop)
				NativeView.AddGestureRecognizer(new UISwipeGestureRecognizer(g => _page.DoSwipeBottomToTop ()) {Direction = UISwipeGestureRecognizerDirection.Up});

			if (_page.HasSwipeTopToBottom)
				NativeView.AddGestureRecognizer(new UISwipeGestureRecognizer(g => _page.DoSwipeTopToBottom ()) {Direction = UISwipeGestureRecognizerDirection.Down});

			if (_page.HasTap)
				NativeView.AddGestureRecognizer(new UITapGestureRecognizer(g => _page.DoTap ()) {NumberOfTapsRequired = 1});

			if (_page.HasLongTap)
				NativeView.AddGestureRecognizer(new UILongPressGestureRecognizer(g => _page.DoLongTap ()));
		}
	}

}

