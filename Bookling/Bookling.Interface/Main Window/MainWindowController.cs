//
// MainWindowController.cs
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using Bookling.Controller;
using Bookling.Models;

namespace Bookling.Interface
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		private LibraryListViewController listViewController;
		private LibraryGridViewController gridViewController;
		private LibraryManager libraryManager;
		private NSViewController currentController;
		
		public List <Book> Books {
			get {
				return libraryManager.Books;
			}
		}

		#region Constructors
		
		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			libraryManager = new LibraryManager ();
			listViewController = new LibraryListViewController ();
			gridViewController = new LibraryGridViewController ();
			currentController = listViewController;
			libraryViewBox.ContentView = listViewController.View;
		}
		
		#endregion
		
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
		partial void ShowAboutDialog (MonoMac.Foundation.NSObject sender)
		{
			AboutDialogController about = new AboutDialogController ();
			about.Window.MakeKeyAndOrderFront (Window);
		}
		
		partial void ShowPreferencesDialog (MonoMac.Foundation.NSObject sender)
		{
			PreferencesDialogController prefs = new PreferencesDialogController ();
			prefs.Window.MakeKeyAndOrderFront (this);
		}
		
		partial void ShowInfoDialog (MonoMac.Foundation.NSObject sender)
		{
			BookMetadataDialogController info = new BookMetadataDialogController();
			info.Window.MakeKeyAndOrderFront (this);
		}
		
		partial void ImportFile (MonoMac.Foundation.NSObject sender)
		{
			NSOpenPanel filePanel = NSOpenPanel.OpenPanel;
			string[] allowedFileTypes = {"pdf", "epub", "mobi"};
			filePanel.AllowedFileTypes = allowedFileTypes;
			
			int result = filePanel.RunModal();
			if (result == 1) {
				String bookPath = filePanel.Url.ToString ().Replace ("%20", " ");
				Book book = new Book();
				book.Title = Path.GetFileNameWithoutExtension (bookPath);
				book.FilePath = bookPath;
				Console.WriteLine (book.Title + " " + book.FilePath);
				libraryManager.AddBook (book);
			}
			libraryManager.PrintLibrary ();
		}

		partial void ViewAsList (MonoMac.Foundation.NSObject sender)
		{
			while (viewSegmentedControl.Tag == 0) {
				libraryViewBox.ContentView = listViewController.View;
			}
		}
		
		partial void ViewAsGrid (MonoMac.Foundation.NSObject sender)
		{

		}

		void SwitchToController(NSViewController theController)
		{
			if (theController == currentController) {
				return;
			}
			//if (currentController.
		}
	}
}

