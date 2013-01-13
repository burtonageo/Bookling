//
// LightWindow.cs
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


namespace Bookling.Interface
{
	[Register ("LightWindow")]
	public class LightWindow : MonoMac.AppKit.NSWindow
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public LightWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public LightWindow (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
#endregion
		
		[Export ("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			
			if (NSScreen.MainScreen.BackingScaleFactor > 1.0f) {
				AssignBackgroundImage ("lightwindow.card_@2X.png");
			} else {
				AssignBackgroundImage ("lightwindow.card.png");
			}
		}
		
		protected void AssignBackgroundImage (String backgroundFileName)
		{
			BackgroundColor = NSColor.FromPatternImage (NSImage.FromStream (
				Assembly.GetExecutingAssembly ().
				GetManifestResourceStream (backgroundFileName)));		
		}
	}
}
