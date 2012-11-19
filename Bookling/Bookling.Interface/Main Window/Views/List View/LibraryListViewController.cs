
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace Bookling
{
	public partial class LibraryListViewController : MonoMac.AppKit.NSViewController
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public LibraryListViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public LibraryListViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public LibraryListViewController () : base ("LibraryListView", NSBundle.MainBundle)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		
		//strongly typed view accessor
		public new LibraryListView View {
			get {
				return (LibraryListView)base.View;
			}
		}
	}
}

