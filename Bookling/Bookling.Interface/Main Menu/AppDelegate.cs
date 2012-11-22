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
using System.Drawing;
using System.IO;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using Bookling.Interface;

namespace Bookling.Controller
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		private MainWindowController mainWindowController;
		private LibraryManager libraryManager;

		public AppDelegate ()
		{

		}

		public override void FinishedLaunching (NSObject notification)
		{
			libraryManager = new LibraryManager ();

			mainWindowController = new MainWindowController ();
			mainWindowController.Window.MakeKeyAndOrderFront (this);
		}

		partial void ShowAboutDialog (MonoMac.Foundation.NSObject sender)
		{
			AboutDialogController about = new AboutDialogController ();
			about.Window.MakeKeyAndOrderFront (mainWindowController.Window);
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
	}
}

