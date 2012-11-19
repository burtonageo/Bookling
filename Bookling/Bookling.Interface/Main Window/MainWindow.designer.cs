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
		MonoMac.AppKit.NSBox LibraryViewBox { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LibraryViewBox != null) {
				LibraryViewBox.Dispose ();
				LibraryViewBox = null;
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
