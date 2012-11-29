// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling.Interface
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSBox libraryViewBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSToolbarItem viewSegmentedControl { get; set; }

		[Outlet]
		MonoMac.AppKit.NSToolbarItem shareButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSMenuItem listViewMenuItem { get; set; }

		[Outlet]
		MonoMac.AppKit.NSMenuItem gridViewMenuItem { get; set; }

		[Action ("showAboutDialog:")]
		partial void ShowAboutDialog (MonoMac.Foundation.NSObject sender);

		[Action ("showPreferencesDialog:")]
		partial void ShowPreferencesDialog (MonoMac.Foundation.NSObject sender);

		[Action ("showInfoDialog:")]
		partial void ShowInfoDialog (MonoMac.Foundation.NSObject sender);

		[Action ("importFile:")]
		partial void ImportFile (MonoMac.Foundation.NSObject sender);

		[Action ("viewAsList:")]
		partial void ViewAsList (MonoMac.Foundation.NSObject sender);

		[Action ("viewAsGrid:")]
		partial void ViewAsGrid (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (libraryViewBox != null) {
				libraryViewBox.Dispose ();
				libraryViewBox = null;
			}

			if (viewSegmentedControl != null) {
				viewSegmentedControl.Dispose ();
				viewSegmentedControl = null;
			}

			if (shareButton != null) {
				shareButton.Dispose ();
				shareButton = null;
			}

			if (listViewMenuItem != null) {
				listViewMenuItem.Dispose ();
				listViewMenuItem = null;
			}

			if (gridViewMenuItem != null) {
				gridViewMenuItem.Dispose ();
				gridViewMenuItem = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		MonoMac.AppKit.NSBox LibraryViewBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSToolbarItem ShareButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSOutlineView LibrarySourceList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LibraryViewBox != null) {
				LibraryViewBox.Dispose ();
				LibraryViewBox = null;
			}

			if (ShareButton != null) {
				ShareButton.Dispose ();
				ShareButton = null;
			}

			if (LibrarySourceList != null) {
				LibrarySourceList.Dispose ();
				LibrarySourceList = null;
			}
		}
	}
}
