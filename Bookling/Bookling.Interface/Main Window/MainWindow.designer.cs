// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling.Interface
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		public MonoMac.AppKit.NSBox LibraryViewBox { get; set; }

		[Outlet]
		public MonoMac.AppKit.NSToolbarItem ShareButton { get; set; }

		[Outlet]
		public MonoMac.AppKit.NSOutlineView LibrarySourceList { get; set; }
		
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

	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
