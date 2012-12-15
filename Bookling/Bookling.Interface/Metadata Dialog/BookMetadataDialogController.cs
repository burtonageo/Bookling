
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

			// Make sure checkbox and series fields are in sync
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
				seriesField.Enabled = false;
				seriesStartField.Enabled = false;
				seriesEndField.Enabled = false;
			} else {
				seriesField.Enabled = true;
				seriesStartField.Enabled = true;
				seriesEndField.Enabled = true;
			}
		}
	}
}

