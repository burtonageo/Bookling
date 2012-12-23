//
// LibraryListViewController.cs
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
using System.Collections;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using Bookling.Models;
using Bookling.Controller;

namespace Bookling.Interface
{
	public partial class LibraryListViewController : MonoMac.AppKit.NSViewController
	{
		public ArrayList Books {
			get;
			set;
		}

		private LibraryDatabaseManager manager;
		private LibraryListViewDataSource source;
	
		#region Constructors
		
		// Called when created from unmanaged code
		public LibraryListViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public LibraryListViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public LibraryListViewController () : base ("LibraryListView", NSBundle.MainBundle)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		
		//strongly typed view accessor
		public new LibraryListView View {
			get {
				return (LibraryListView)base.View;
			}
		}

		[Export("AwakeFromNib")]
		public override void AwakeFromNib ()
		{
			manager = new LibraryDatabaseManager ();
			//source = new LibraryListViewDataSource (manager.Books);
			//Console.WriteLine (manager.Books.Count);
			tableView.DataSource = source;
			tableView.BackgroundColor = NSColor.FromCalibratedRgba (0.0f, 0.0f, 0.0f, 0.0f);
		}

		
		[Register("LibraryListViewDataSource")]
		private class LibraryListViewDataSource : NSTableViewDataSource
		{
			//private ArrayList books;
			
			[Export("init")]
			public LibraryListViewDataSource ()
			{
			}

			public LibraryListViewDataSource (ArrayList bookList)
			{
				//books = bookList;
			}
			
			[Export ("numberOfRowsInTableView:")]
			public int NumberOfRowsInTableView (NSTableView table)
			{
				return 10;//books.Count;
			}
			
			[Export ("tableView:objectValueForTableColumn:row:")]
			public NSObject ObjectValueForTableColumn (
				NSTableView table, NSTableColumn col, int row)
			{
				return new NSString ("Hello");
			}
		}
	}
}

