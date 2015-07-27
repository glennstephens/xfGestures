using System;
using Xamarin.Forms;

namespace XFGesturedControlDemo
{
	public class GesturedFrame : Frame, IGestureCapture
	{
		public GesturedFrame() : base() { 
			HasShadow = false;
			this.OutlineColor = Color.Transparent;
			this.Padding = new Thickness (0);
		}

		public event EventHandler OnSwipeLeftToRight = delegate {};
		public event EventHandler OnSwipeRightToLeft = delegate {};
		public event EventHandler OnSwipeTopToBottom = delegate {};
		public event EventHandler OnSwipeBottomToTop = delegate {};
		public event EventHandler OnTap = delegate {};
		public event EventHandler OnLongTap = delegate {};

		public bool HasSwipeLeftToRight { get { return OnSwipeLeftToRight != null; } }
		public bool HasSwipeRightToLeft { get { return OnSwipeRightToLeft != null; } }
		public bool HasSwipeTopToBottom { get { return OnSwipeTopToBottom != null; } }
		public bool HasSwipeBottomToTop { get { return OnSwipeBottomToTop != null; } }
		public bool HasTap { get { return OnTap != null; } }
		public bool HasLongTap { get { return OnLongTap != null; } }

		public void DoSwipeLeftToRight () 
		{
			OnSwipeLeftToRight?.Invoke (this, EventArgs.Empty);
		}

		public void DoSwipeRightToLeft ()
		{
			OnSwipeRightToLeft?.Invoke (this, EventArgs.Empty);
		}

		public void DoSwipeTopToBottom ()
		{
			OnSwipeTopToBottom?.Invoke (this, EventArgs.Empty);
		}

		public void DoSwipeBottomToTop() 
		{
			OnSwipeBottomToTop?.Invoke (this, EventArgs.Empty);
		}

		public void DoTap()
		{
			OnTap?.Invoke (this, EventArgs.Empty);
		}

		public void DoLongTap()
		{
			OnLongTap?.Invoke (this, EventArgs.Empty);
		}
	}
}
