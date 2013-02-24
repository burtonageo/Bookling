//
// BookMetadataDialogController.cs
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
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling.Interface
{
	public partial class BookMetadataDialogController : MonoMac.AppKit.NSWindowController
	{
		#region Properties

		public bool IsPartOfSeries {
			get {
				switch (isSeriesCheckBox.State) {
				case NSCellStateValue.Off:
					return false;
				default:
					return true;
				}
			}
		}

		#endregion
		#region Constructors
		
		// Called when created from unmanaged code
		public BookMetadataDialogController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public BookMetadataDialogController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public BookMetadataDialogController () : base ("BookMetadataDialog")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		#region Methods

		//strongly typed window accessor
		public new BookMetadataDialog Window {
			get {
				return (BookMetadataDialog)base.Window;
			}
		}

		[Export("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			Window.CloseButton.Target = this;
			Window.CloseButton.Action = new Selector ("CloseWindow:");

			// Make sure checkbox and series fields are in sync,
			// using a dummy NSObject.
			SwitchIsInSeries (new NSObject ());
		} 

		partial void CloseWindow (MonoMac.Foundation.NSObject sender)
		{
			Window.Close ();
			NSApplication.SharedApplication.StopModal ();
		}

		partial void SwitchIsInSeries (MonoMac.Foundation.NSObject sender)
		{
			if (!IsPartOfSeries) {
				seriesStartField.StringValue = "";
				seriesField.StringValue = "";
				seriesEndField.StringValue = "";

				seriesField.Enabled = false;
				seriesStartField.Enabled = false;
				seriesEndField.Enabled = false;
			} else {
				seriesField.Enabled = true;
				seriesStartField.Enabled = true;
				seriesEndField.Enabled = true;
			}
		}

		#endregion
	}
}

