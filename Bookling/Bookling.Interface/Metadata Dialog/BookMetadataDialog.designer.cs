// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling
{
	[Register ("BookMetadataDialogController")]
	partial class BookMetadataDialogController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField TitleField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField AuthorField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField GenreField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField YearField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField SeriesField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField SeriesStartField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField SeriesEndField { get; set; }

		[Action ("AcceptChanges:")]
		partial void AcceptChanges (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleField != null) {
				TitleField.Dispose ();
				TitleField = null;
			}

			if (AuthorField != null) {
				AuthorField.Dispose ();
				AuthorField = null;
			}

			if (GenreField != null) {
				GenreField.Dispose ();
				GenreField = null;
			}

			if (YearField != null) {
				YearField.Dispose ();
				YearField = null;
			}

			if (SeriesField != null) {
				SeriesField.Dispose ();
				SeriesField = null;
			}

			if (SeriesStartField != null) {
				SeriesStartField.Dispose ();
				SeriesStartField = null;
			}

			if (SeriesEndField != null) {
				SeriesEndField.Dispose ();
				SeriesEndField = null;
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
