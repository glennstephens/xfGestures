using System;
using Xamarin.Forms;

namespace XFGesturedControlDemo
{
	public interface IGestureCapture
	{
		bool HasSwipeLeftToRight { get; }
		bool HasSwipeRightToLeft { get; }
		bool HasSwipeTopToBottom { get; }
		bool HasSwipeBottomToTop { get; }
		bool HasTap { get; }
		bool HasLongTap { get; }

		void DoSwipeLeftToRight (); 
		void DoSwipeRightToLeft ();
		void DoSwipeTopToBottom ();
		void DoSwipeBottomToTop (); 
		void DoTap();
		void DoLongTap();
	}
	
}
