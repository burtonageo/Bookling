
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace Bookling
{
	public partial class LibraryGridViewController : MonoMac.AppKit.NSViewController
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public LibraryGridViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public LibraryGridViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public LibraryGridViewController () : base ("LibraryGridView", NSBundle.MainBundle)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		
		//strongly typed view accessor
		public new LibraryGridView View {
			get {
				return (LibraryGridView)base.View;
			}
		}
	}
}

