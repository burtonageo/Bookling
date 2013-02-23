
using System;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling.Interface
{
	public partial class AboutDialogController : MonoMac.AppKit.NSWindowController
	{
		#region Properties
		
		//strongly typed window accessor
		public new AboutDialog Window {
			get {
				return (AboutDialog)base.Window;
			}
		}

		#endregion
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
		#region Methods

		[Export("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			Window.CloseButton.Target = this;
			Window.CloseButton.Action = 
				new Selector ("CloseWindow:");
		}

		override public void Close ()
		{
			NSApplication.SharedApplication.StopModal ();
			base.Close ();
		}

		partial void CloseWindow (MonoMac.Foundation.NSObject sender)
		{
			Close ();
		}

		partial void VisitWebsite (MonoMac.Foundation.NSObject sender)
		{
			NSWorkspace.SharedWorkspace.OpenUrl
				(NSUrl.FromString ("https://github.com/burtonageo/Bookling"));
		}

		#endregion
	}
}

 