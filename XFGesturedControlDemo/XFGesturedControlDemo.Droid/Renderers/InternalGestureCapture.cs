using System;
using Android.Views;
using XFGesturedControlDemo;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFGesturedControlDemo.Droid;

[assembly: ExportRenderer (typeof (GesturedContentPage), typeof (GesturedPageRenderer))]

namespace XFGesturedControlDemo.Droid
{
	public class InternalGestureCapture : Java.Lang.Object, GestureDetector.IOnGestureListener
	{
		const int MinSwipeDistance = 120;
		const int MaxSwipeOffPath = 250;
		const int SwipeThreadsholdVelocity = 200;

		IGestureCapture gesturedControl;

		public InternalGestureCapture(IGestureCapture gesturedControl)
		{
			this.gesturedControl = gesturedControl;
		}

		public bool OnDown (MotionEvent e)
		{
			return true;
		}

		public bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			// Right to left swipe
			if (e1.GetX() - e2.GetX() > MinSwipeDistance
				&& Math.Abs(velocityX) > SwipeThreadsholdVelocity) {
				gesturedControl?.DoSwipeRightToLeft ();
			} 
			// Left to right swipe
			else if (e2.GetX() - e1.GetX() > MinSwipeDistance
				&& Math.Abs(velocityX) > SwipeThreadsholdVelocity) {
				gesturedControl?.DoSwipeLeftToRight ();
			}

			if (e1.GetY() - e2.GetY() > MinSwipeDistance
				&& Math.Abs(velocityY) > SwipeThreadsholdVelocity) {
				gesturedControl?.DoSwipeBottomToTop ();
			} 
			// Left to right swipe
			else if (e2.GetY() - e1.GetY() > MinSwipeDistance
				&& Math.Abs(velocityY) > SwipeThreadsholdVelocity) {
				gesturedControl?.DoSwipeTopToBottom ();
			}

			return true;
		}

		public bool OnSingleTapUp (MotionEvent e)
		{
			gesturedControl?.DoTap ();

			return true;
		}

		public void OnLongPress (MotionEvent e)
		{
			gesturedControl?.DoLongTap ();
		}

		public bool OnScroll (MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}

		public void OnShowPress (MotionEvent e)
		{
		}
	}
	
}
