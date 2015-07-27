using System;
using Xamarin.Forms;
using System.ServiceModel;

namespace XFGesturedControlDemo
{
	/// <summary>
	/// Sample page demonstrating how to use a Gesture Page in code
	/// </summary>
	public class CodeGestureDemoPage : GesturedContentPage
	{
		public CodeGestureDemoPage ()
		{
			Title = "Code Gesture Page";

			var directionDisplay = new Label () {
				Text = "Swipe to Update",
				FontSize = 30,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			Content = directionDisplay;

			OnSwipeLeftToRight += (sender, args) => directionDisplay.Text = "-->";
			OnSwipeRightToLeft += (sender, args) => directionDisplay.Text = "<--";
			OnSwipeTopToBottom += (sender, args) => directionDisplay.Text = "\\/";
			OnSwipeBottomToTop += (sender, args) => directionDisplay.Text = "/\\";
			OnTap += (sender, args) => directionDisplay.Text = "Tapped";
			OnLongTap += (sender, args) => directionDisplay.Text = "Long Tap";
		}
	}
}

