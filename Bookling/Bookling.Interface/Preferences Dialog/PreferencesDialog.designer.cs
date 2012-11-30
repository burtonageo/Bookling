// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Bookling.Interface
{
	[Register ("PreferencesDialogController")]
	partial class PreferencesDialogController
	{
		[Outlet]
		MonoMac.AppKit.NSSegmentedControl viewSelector { get; set; }

		[Outlet]
		MonoMac.AppKit.NSBox viewBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton acceptButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton resetButton { get; set; }

		[Action ("ResetToDefaults:")]
		partial void ResetToDefaults (MonoMac.Foundation.NSObject sender);

		[Action ("Accept:")]
		partial void Accept (MonoMac.Foundation.NSObject sender);

		[Action ("Cancel:")]
		partial void Cancel (MonoMac.Foundation.NSObject sender);

		[Action ("SwitchView:")]
		partial void SwitchView (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (viewSelector != null) {
				viewSelector.Dispose ();
				viewSelector = null;
			}

			if (viewBox != null) {
				viewBox.Dispose ();
				viewBox = null;
			}

			if (acceptButton != null) {
				acceptButton.Dispose ();
				acceptButton = null;
			}

			if (resetButton != null) {
				resetButton.Dispose ();
				resetButton = null;
			}
		}
	}

	[Register ("PreferencesDialog")]
	partial class PreferencesDialog
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
