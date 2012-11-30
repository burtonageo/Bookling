
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace Bookling
{
	public partial class AboutDialogController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public AboutDialogController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public AboutDialogController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public AboutDialogController () : base ("AboutDialog")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{

		}
		
		#endregion
		
		//strongly typed window accessor
		public new AboutDialog Window {
			get {
				return (AboutDialog)base.Window;
			}
		}

		partial void CloseWindow (MonoMac.Foundation.NSObject sender)
		{
			this.Window.OrderOut (sender);
			NSApplication.SharedApplication.StopModal ();
		}

		partial void VisitWebsite (MonoMac.Foundation.NSObject sender)
		{
			NSWorkspace.SharedWorkspace.OpenUrl (new NSUrl 
			                                     ("https://github.com/burtonageo/Bookling", 
			 									  isDir: false));
		}
	}
}

 