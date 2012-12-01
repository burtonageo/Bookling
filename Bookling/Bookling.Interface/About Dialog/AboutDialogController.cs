
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace Bookling
{
	public partial class AboutDialogController : MonoMac.AppKit.NSWindowController
	{
		private NSButton windowCloseButton;
		private NSButton windowMinimizeButton;
		private NSButton windowMaximizeButton;


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

			windowCloseButton = Window.StandardWindowButton (NSWindowButton.CloseButton);
			windowMinimizeButton = Window.StandardWindowButton (NSWindowButton.MiniaturizeButton);
			windowMaximizeButton = Window.StandardWindowButton (NSWindowButton.ZoomButton);			                                         

			windowMaximizeButton.Hidden = true;
			windowMinimizeButton.Hidden = true;

			windowCloseButton.Target = this;
			windowCloseButton.Action = new MonoMac.ObjCRuntime.Selector ("CloseWindow:");

			windowCloseButton.Bordered = false;
			windowCloseButton.Image = NSImage.FromStream 
				(Assembly.GetExecutingAssembly ().
				 GetManifestResourceStream 
				 ("Bookling.Icons.close.png"));

			Window.BackgroundColor = NSColor.FromPatternImage (NSImage.FromStream 
			            (Assembly.GetExecutingAssembly ().
			 			GetManifestResourceStream 
			               ("Bookling.Textures.paper.png")));
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
	}
}

 