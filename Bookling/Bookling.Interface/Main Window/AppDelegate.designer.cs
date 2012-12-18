// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling.Interface
{
	[Register ("AppDelegate")]
	partial class AppDelegate
	{
		[Outlet]
		MonoMac.AppKit.NSWindow mainWindow { get; set; }

		[Outlet]
		MonoMac.AppKit.NSBox libraryBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSOutlineView librarySourceOutline { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSegmentedControl viewSwitcher { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSearchField searchBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton shareButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSMenuItem listViewMenuItem { get; set; }

		[Outlet]
		MonoMac.AppKit.NSMenuItem gridViewMenuItem { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSplitView splitView { get; set; }

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

		[Action ("SwitchView:")]
		partial void SwitchView (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (mainWindow != null) {
				mainWindow.Dispose ();
				mainWindow = null;
			}

			if (libraryBox != null) {
				libraryBox.Dispose ();
				libraryBox = null;
			}

			if (librarySourceOutline != null) {
				librarySourceOutline.Dispose ();
				librarySourceOutline = null;
			}

			if (viewSwitcher != null) {
				viewSwitcher.Dispose ();
				viewSwitcher = null;
			}

			if (searchBox != null) {
				searchBox.Dispose ();
				searchBox = null;
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

			if (splitView != null) {
				splitView.Dispose ();
				splitView = null;
			}
		}
	}
}
