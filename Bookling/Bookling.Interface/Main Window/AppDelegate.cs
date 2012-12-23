//
// AppDelegate.cs
//
// Author:
//       georgeburton <burtonageo@gmail.com>
//
// Copyright (c) 2012 georgeburton
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using Bookling;
using Bookling.Controller;
using Bookling.Models;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using Bookling.Interface;

namespace Bookling.Interface
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		private LibraryListViewController listViewController;
		private LibraryGridViewController gridViewController;
		private LibraryDatabaseManager libraryManager;
		private NSViewController currentController;
		
		public ArrayList Books {
			get {
				return libraryManager.Books;
			}
		}

		public AppDelegate ()
		{

		}

		public override void FinishedLaunching (NSObject notification)
		{
			libraryManager = new LibraryDatabaseManager ();
			listViewController = new LibraryListViewController ();
			gridViewController = new LibraryGridViewController ();
			SwitchToController (listViewController);
			mainWindow.MakeKeyAndOrderFront (this);
		}


		public override bool 
			ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender)
		{
			return true;
		}

		partial void ShowAboutDialog (MonoMac.Foundation.NSObject sender)
		{
			AboutDialogController about = new AboutDialogController ();
			about.Window.MakeKeyAndOrderFront (this.mainWindow);
			about.Window.SetFrameTopLeftPoint (new PointF (
				mainWindow.Frame.Left + 
				((mainWindow.Frame.Right - about.Window.Frame.Right) / 2), 
				mainWindow.Frame.Bottom - 35));
			NSApplication.SharedApplication.RunModalForWindow (about.Window);
		}
		
		partial void ShowPreferencesDialog (MonoMac.Foundation.NSObject sender)
		{
			PreferencesDialogController prefs = new PreferencesDialogController ();
			prefs.Window.MakeKeyAndOrderFront (this.mainWindow);
			prefs.Window.SetFrameTopLeftPoint (new PointF (
				mainWindow.Frame.Left + 
				((mainWindow.Frame.Right - prefs.Window.Frame.Right) / 2), 
				mainWindow.Frame.Bottom - 20));
			NSApplication.SharedApplication.RunModalForWindow (prefs.Window);
		}
		
		partial void ShowInfoDialog (MonoMac.Foundation.NSObject sender)
		{
			BookMetadataDialogController info = new BookMetadataDialogController();
			info.Window.MakeKeyAndOrderFront (this.mainWindow);
			info.Window.SetFrameTopLeftPoint (new PointF(
				(mainWindow.Frame.Right - info.Window.Frame.Left) / 4, mainWindow.Frame.Bottom));
		}
		
		partial void ImportFile (MonoMac.Foundation.NSObject sender)
		{
			NSOpenPanel filePanel = NSOpenPanel.OpenPanel;
			string[] allowedFileTypes = {"pdf", "epub", "mobi"};
			filePanel.AllowedFileTypes = allowedFileTypes;
			
			int result = filePanel.RunModal();
			//NSApplication.SharedApplication.BeginSheet (filePanel, mainWindow);
			if (result == 1) {
				String bookPath = filePanel.Url.ToString ().Replace ("%20", " ");
				Book book = new Book();
				book.Title = Path.GetFileNameWithoutExtension (bookPath);
				book.FilePath = bookPath;
				Console.WriteLine (book.Title + " " + book.FilePath);
				libraryManager.AddBook (book);
				listViewController.tableView.ReloadData ();
			}
			//NSApplication.SharedApplication.EndSheet (filePanel);
		}
		
		partial void ViewAsList (MonoMac.Foundation.NSObject sender)
		{
			SwitchToController (listViewController);
		}
		
		partial void ViewAsGrid (MonoMac.Foundation.NSObject sender)
		{
			SwitchToController (gridViewController);
		}

		void SwitchToController (NSViewController theController)
		{
			if (theController == currentController) {
				return;
			}
			libraryBox.ContentView = theController.View;
			currentController = theController;
			if (theController is LibraryGridViewController) {
				gridViewMenuItem.State = NSCellStateValue.On;
				listViewMenuItem.State = NSCellStateValue.Off;
				viewSwitcher.SelectedSegment = 1;
			} else if (theController is LibraryListViewController) {
				gridViewMenuItem.State = NSCellStateValue.Off;
				listViewMenuItem.State = NSCellStateValue.On;
				viewSwitcher.SelectedSegment = 0;
			}
		}
		
		partial void SwitchView (MonoMac.Foundation.NSObject sender)
		{
			switch (viewSwitcher.SelectedSegment) {
			case 0:
				SwitchToController (listViewController);
				break;
			case 1:
				SwitchToController (gridViewController);
				break;
			}
		}

	}
}

