// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling.Interface
{
	[Register ("LibraryListViewController")]
	partial class LibraryListViewController
	{
		[Outlet]
		public MonoMac.AppKit.NSTableView tableView { get; private set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}

	[Register ("LibraryListView")]
	partial class LibraryListView
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
