
using System;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling.Interface
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

		[Export("awakeFromNib")]
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			Window.CloseButton.Target = this;
			Window.CloseButton.Action = 
				new Selector ("CloseWindow:");
		}

		partial void CloseWindow (MonoMac.Foundation.NSObject sender)
		{
			NSApplication.SharedApplication.StopModal ();
			Close ();
		}

		partial void VisitWebsite (MonoMac.Foundation.NSObject sender)
		{
			NSWorkspace.SharedWorkspace.OpenUrl
				(NSUrl.FromString ("https://github.com/burtonageo/Bookling"));
		}

		partial void SwitchView (MonoMac.Foundation.NSObject sender)
		{

		}
	}
}

 