using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFGesturedControlDemo
{
	public class MenuOptionsPage : ContentPage
	{
		const string codeBasedGesturePage = "Code based Gesture Page";
		const string XAMLBasedGesturePage = "XAML based Gesture Page";
		const string codeBasedGestureControl = "Code based Gesture Control";

		public MenuOptionsPage ()
		{
			Title = "Menu";

			var listView = new ListView {
				ItemsSource = new [] { 
					codeBasedGesturePage,
					XAMLBasedGesturePage,
					codeBasedGestureControl,
				},
				ItemTemplate = new DataTemplate (typeof(TextCell)) {
					Bindings = {
						{ TextCell.TextProperty, new Binding (".") },
					}
				}
			};

			listView.ItemTapped += async (s, e) => {
				switch (e.Item.ToString()) 
				{
					case codeBasedGesturePage:
						await Navigation.PushAsync(new CodeGestureDemoPage());
						break;
					case XAMLBasedGesturePage:
						await Navigation.PushAsync(new XamlGestureDemoPage());
						break;
					case codeBasedGestureControl:
						await Navigation.PushAsync(new GestureFrameDemoPage());
						break;
				}

				listView.SelectedItem = null;
			};

			Content = listView;
		}
	}
}
