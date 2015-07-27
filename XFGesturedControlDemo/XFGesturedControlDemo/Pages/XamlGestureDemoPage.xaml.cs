using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFGesturedControlDemo
{
	public partial class XamlGestureDemoPage : GesturedContentPage
	{
		public XamlGestureDemoPage ()
		{
			InitializeComponent ();

			OnSwipeLeftToRight += (sender, args) => directionDisplay.Text = "-->";
			OnSwipeRightToLeft += (sender, args) => directionDisplay.Text = "<--";
			OnSwipeTopToBottom += (sender, args) => directionDisplay.Text = "\\/";
			OnSwipeBottomToTop += (sender, args) => directionDisplay.Text = "/\\";
			OnTap += (sender, args) => directionDisplay.Text = "Tapped";
			OnLongTap += (sender, args) => directionDisplay.Text = "Long Tap";
		}
	}
}

