// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSBox libraryBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSScrollView librarySources { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSegmentedControl viewSwitcher { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton shareButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSearchField searchField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (libraryBox != null) {
				libraryBox.Dispose ();
				libraryBox = null;
			}

			if (librarySources != null) {
				librarySources.Dispose ();
				librarySources = null;
			}

			if (viewSwitcher != null) {
				viewSwitcher.Dispose ();
				viewSwitcher = null;
			}

			if (shareButton != null) {
				shareButton.Dispose ();
				shareButton = null;
			}

			if (searchField != null) {
				searchField.Dispose ();
				searchField = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
