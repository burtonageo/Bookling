//
// LightDialog.cs
//
// Author:
//       George Burton <burtonageo@gmail.com>
//
// Copyright (c) 2012 George Burton
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Resources;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling.Interface
{
	[Register ("LightDialog")]
	public class LightDialog : MonoMac.AppKit.NSWindow
	{
		public NSButton CloseButton {
			protected set;
			get;
		}

		#region Constructors
		
		// Called when created from unmanaged code
		public LightDialog (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public LightDialog (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			//lightDialogTitleView = new LightDialogTitleView ();
		}
		
#endregion
		
		[Export ("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			CloseButton = new NSButton ();
			CloseButton.BezelStyle = NSBezelStyle.Circular;
			CloseButton.Bordered = false;

			NSButton windowCloseButton = StandardWindowButton (NSWindowButton.CloseButton);
			NSButton windowMinimizeButton = StandardWindowButton (NSWindowButton.MiniaturizeButton);
			NSButton windowZoomButton = StandardWindowButton (NSWindowButton.ZoomButton);			                                         
			
			windowZoomButton.Hidden = true;
			windowZoomButton.Enabled = false;
			windowMinimizeButton.Hidden = true;
			windowMinimizeButton.Enabled = false;
			windowCloseButton.Hidden = true;
			windowCloseButton.Enabled = false;

			if (NSScreen.MainScreen.BackingScaleFactor > 1.0f) {
				AssignImages ("Bookling.Icons.close_@2X.png", "Bookling.Icons.close_pressed_@2X.png",
				              "Bookling.Textures.paper_@2X.png");
			} else {
				AssignImages ("Bookling.Icons.close.png", "Bookling.Icons.close_pressed.png",
				              "Bookling.Textures.paper.png");
			}

			NSView themeFrame = ContentView.Superview;
			RectangleF containerFrame = themeFrame.Frame;
			RectangleF buttonFrame = CloseButton.Frame;
			RectangleF newFrame = new RectangleF (
				1, containerFrame.Size.Height - buttonFrame.Size.Height - 2,
			    buttonFrame.Size.Width, buttonFrame.Size.Height);

			CloseButton.Frame = newFrame;
			themeFrame.AddSubview (CloseButton);
			CloseButton.AutoresizingMask = NSViewResizingMask.MinXMargin | NSViewResizingMask.MinYMargin;
			CloseButton.Enabled = true;
			CloseButton.Target = this;
			CloseButton.Action = new Selector("performClose:");

		}

		private void AssignImages (String closeIconFileName, 
		                           String pressedCloseIconFileName,
		                           String backgroundFileName)
		{
			NSImage closeImage = NSImage.FromStream 
				(Assembly.GetExecutingAssembly ().
				 GetManifestResourceStream (
					closeIconFileName));
			CloseButton.Frame = new RectangleF (new PointF (0.0f, 0.0f), 
			                                    new SizeF (closeImage.Size.Height,
			           closeImage.Size.Width));
			NSImage pressedCloseImage = NSImage.FromStream 
				(Assembly.GetExecutingAssembly ().
				 GetManifestResourceStream (
					pressedCloseIconFileName));
			CloseButton.Frame = new RectangleF (
				new PointF (0.0f, 0.0f), 
				new SizeF (pressedCloseImage.Size.Height,
			           pressedCloseImage.Size.Width));
			
			CloseButton.Image = closeImage;
			CloseButton.AlternateImage = pressedCloseImage;
			CloseButton.Cell.HighlightsBy = (int)NSCellMask.ContentsCell;
			
			BackgroundColor = NSColor.FromPatternImage (NSImage.FromStream (
				Assembly.GetExecutingAssembly ().
			 	GetManifestResourceStream (backgroundFileName)));		

		}
	}
}

