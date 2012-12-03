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
		private NSButton windowCloseButton;
		private NSButton windowMinimizeButton;
		private NSButton windowZoomButton;
		//private NSView lightDialogTitleView;
		//private int buttonId;

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

			windowCloseButton = StandardWindowButton (NSWindowButton.CloseButton);
			windowMinimizeButton = StandardWindowButton (NSWindowButton.MiniaturizeButton);
			windowZoomButton = StandardWindowButton (NSWindowButton.ZoomButton);			                                         
			
			windowZoomButton.Hidden = true;
			windowMinimizeButton.Hidden = true;

			if (NSScreen.MainScreen.BackingScaleFactor > 1.0f) {
				windowCloseButton.Bordered = false;
				windowCloseButton.Image = NSImage.FromStream 
					(Assembly.GetExecutingAssembly ().
					 GetManifestResourceStream (
						"Bookling.Icons.close_@2X.png"));

				BackgroundColor = NSColor.FromPatternImage (NSImage.FromStream 
				                                            (Assembly.GetExecutingAssembly ().
				 GetManifestResourceStream (
					"Bookling.Textures.paper_@2X.png")));
			} else {

				windowCloseButton.Bordered = false;
				windowCloseButton.Image = NSImage.FromStream 
					(Assembly.GetExecutingAssembly ().
					 GetManifestResourceStream (
				 		"Bookling.Icons.close.png"));

				BackgroundColor = NSColor.FromPatternImage (NSImage.FromStream 
					(Assembly.GetExecutingAssembly ().
					 GetManifestResourceStream (
							"Bookling.Textures.paper.png")));		
			}

			/*
			NSView themeFrame = ContentView.Superview;
			NSView firstSubview = themeFrame.Subviews[0];
			lightDialogTitleView.AutoresizingMask = NSViewResizingMask.MaxYMargin;
			themeFrame.AddSubview (lightDialogTitleView, NSWindowOrderingMode.Below, firstSubview);
			*/
		}
	}
}

