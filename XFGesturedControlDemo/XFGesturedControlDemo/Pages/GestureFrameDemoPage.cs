using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace XFGesturedControlDemo
{
	public class GestureFrameDemoPage : ContentPage
	{
		double currentLeft = 0;
		double currentTop = 0;
		double boxSize = 15;

		BoxView mainBox;

		ObservableCollection<string> log = new ObservableCollection<string>();

		public GestureFrameDemoPage ()
		{
			Title = "Coded Gesture Control";

			// Setup the Gesture Area
			GesturedFrame gestureArea = new GesturedFrame() { HeightRequest = 300 };

			var boxAnimLayout = new AbsoluteLayout () { BackgroundColor = Color.FromHex ("FCFCFC") };

			mainBox = new BoxView () { IsVisible = true, BackgroundColor = Color.Black };

			boxAnimLayout.Children.Add (mainBox, new Rectangle (currentLeft, currentTop, boxSize, boxSize));

			gestureArea.Content = boxAnimLayout;

			const int movementAmount = 75;

			gestureArea.OnSwipeLeftToRight += async (sender, args) => {
				log.Add("Swipe to Right");
				await MoveBox (movementAmount, 0);
			};
			gestureArea.OnSwipeRightToLeft += async (sender, args) => {
				log.Add("Swipe to Left");
				await MoveBox (-movementAmount, 0);
			};
			gestureArea.OnSwipeTopToBottom += async (sender, args) => {
				log.Add("Swipe to Bottom");
				await MoveBox (0, movementAmount);
			};
			gestureArea.OnSwipeBottomToTop += async (sender, args) => {
				log.Add("Swipe to Top");
				await MoveBox (0, -movementAmount);
			};
			gestureArea.OnTap += async (sender, args) => {
				log.Add("Tap");
				await ScaleBox (2);
			};
			gestureArea.OnLongTap += async (sender, args) => {
				log.Add("Long Press");
				await ScaleBox (1);
			};

			// Setup the Logger
	        var listView = new ListView
	        {
	            ItemsSource = log,
				ItemTemplate = new DataTemplate(typeof (TextCell))
	            {
	                Bindings =
	                {
	                    {TextCell.TextProperty, new Binding(".")},
	                }
	            }
			};

			RelativeLayout layout = new RelativeLayout ();
			layout.Children.Add (gestureArea, 
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent (p => p.Width),
				Constraint.RelativeToParent (p => p.Height - 200));
			layout.Children.Add (listView, 
				Constraint.Constant (0),
				Constraint.RelativeToParent (p => p.Height - 200),
				Constraint.RelativeToParent (p => p.Width),
				Constraint.Constant(200));

			Content = layout;
		}

		async Task MoveBox(double deltaX, double deltaY)
		{
			currentLeft += deltaX;
			currentTop += deltaY;

			await mainBox.TranslateTo (currentLeft, currentTop, 222, Easing.CubicInOut);
		}

		async Task ScaleBox(double amount)
		{
			await mainBox.ScaleTo(amount, 250, Easing.CubicInOut);
		}
	}
}
