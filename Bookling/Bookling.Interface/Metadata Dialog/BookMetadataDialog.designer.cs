// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling.Interface
{
	[Register ("BookMetadataDialogController")]
	partial class BookMetadataDialogController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField titleField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField authorField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField genreField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField yearField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField seriesField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField seriesStartField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField seriesEndField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton isSeriesCheckBox { get; set; }

		[Action ("AcceptChanges:")]
		partial void AcceptChanges (MonoMac.Foundation.NSObject sender);

		[Action ("CloseWindow:")]
		partial void CloseWindow (MonoMac.Foundation.NSObject sender);

		[Action ("NextItem:")]
		partial void NextItem (MonoMac.Foundation.NSObject sender);

		[Action ("PreviousItem:")]
		partial void PreviousItem (MonoMac.Foundation.NSObject sender);

		[Action ("SwitchIsInSeries:")]
		partial void SwitchIsInSeries (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (titleField != null) {
				titleField.Dispose ();
				titleField = null;
			}

			if (authorField != null) {
				authorField.Dispose ();
				authorField = null;
			}

			if (genreField != null) {
				genreField.Dispose ();
				genreField = null;
			}

			if (yearField != null) {
				yearField.Dispose ();
				yearField = null;
			}

			if (seriesField != null) {
				seriesField.Dispose ();
				seriesField = null;
			}

			if (seriesStartField != null) {
				seriesStartField.Dispose ();
				seriesStartField = null;
			}

			if (seriesEndField != null) {
				seriesEndField.Dispose ();
				seriesEndField = null;
			}

			if (isSeriesCheckBox != null) {
				isSeriesCheckBox.Dispose ();
				isSeriesCheckBox = null;
			}
		}
	}

	[Register ("BookMetadataDialog")]
	partial class BookMetadataDialog
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
