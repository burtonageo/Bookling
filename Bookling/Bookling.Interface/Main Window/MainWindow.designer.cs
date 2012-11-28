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
		[Action ("ShowAboutDialog:")]
		partial void ShowAboutDialog (MonoMac.Foundation.NSObject sender);

		[Action ("ShowPreferencesDialog:")]
		partial void ShowPreferencesDialog (MonoMac.Foundation.NSObject sender);

		[Action ("ShowInfoDialog:")]
		partial void ShowInfoDialog (MonoMac.Foundation.NSObject sender);

		[Action ("ImportFile:")]
		partial void ImportFile (MonoMac.Foundation.NSObject sender);

		[Action ("ViewAsList:")]
		partial void ViewAsList (MonoMac.Foundation.NSObject sender);

		[Action ("ViewAsGrid:")]
		partial void ViewAsGrid (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
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
