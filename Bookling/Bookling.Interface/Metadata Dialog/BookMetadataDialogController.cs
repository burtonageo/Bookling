
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling.Interface
{
	public partial class BookMetadataDialogController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public BookMetadataDialogController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public BookMetadataDialogController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public BookMetadataDialogController () : base ("BookMetadataDialog")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		
		//strongly typed window accessor
		public new BookMetadataDialog Window {
			get {
				return (BookMetadataDialog)base.Window;
			}
		}

		[Export("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			Window.StandardWindowButton (NSWindowButton.CloseButton).Target = this;
			Window.StandardWindowButton (NSWindowButton.CloseButton).Action = 
				new Selector ("CloseWindow:");
		}

		partial void CloseWindow (MonoMac.Foundation.NSObject sender)
		{
			Window.Close ();
			NSApplication.SharedApplication.StopModal ();
		}
	}
}

