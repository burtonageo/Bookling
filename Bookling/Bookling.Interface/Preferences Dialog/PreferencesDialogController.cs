//
// PreferencesDialogController.cs
//
// Author:
//       georgeburton <burtonageo@gmail.com>
//
// Copyright (c) 2012 georgeburton
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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling.Interface
{
	public partial class PreferencesDialogController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public PreferencesDialogController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public PreferencesDialogController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public PreferencesDialogController () : base ("PreferencesDialog")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{

		}

		
		#endregion
		
		//strongly typed window accessor
		public new PreferencesDialog Window {
			get {
				return (PreferencesDialog)base.Window;
			}
		}

		[Export("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			Window.CloseButton.Target = this;
			Window.CloseButton.Action = 
				new Selector ("Cancel:");
		}

		partial void ResetToDefaults (MonoMac.Foundation.NSObject sender)
		{

		}
		
		partial void Accept (MonoMac.Foundation.NSObject sender)
		{
			NSApplication.SharedApplication.StopModal ();
			Window.OrderOut (sender);
		}
		
		partial void Cancel (MonoMac.Foundation.NSObject sender)
		{
			NSApplication.SharedApplication.StopModal ();
			Window.OrderOut (sender);
		}


		
		partial void SwitchView (MonoMac.Foundation.NSObject sender)
		{
			switch (viewSelector.SelectedSegment) {
			case 0:
				break;
			case 1:
				break;
			case 2:
				break;
			}
		}

	}
}

