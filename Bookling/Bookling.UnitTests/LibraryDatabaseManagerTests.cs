//
// LibraryManagerTest.cs
//
// Author:
//       George Burton <burtonageo@gmail.com>
//
// Copyright (c) 2012 George Burton
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
using System.IO;
using NUnit.Framework;
using Bookling.Controller;
using Bookling.Models;

namespace Bookling.UnitTests
{
	[TestFixture]
	public class LibraryDatabaseManagerTests
	{
		private LibraryDatabaseManager testManager;
		private String configFolderString;
		private Book book;

		[TestFixtureSetUp]
		public void CreateConfigFolder ()
		{
			configFolderString = String.Format (Environment.GetFolderPath (
				Environment.SpecialFolder.MyDocuments) + "{0}Bookling-Tests{0}", 
			                                    Path.DirectorySeparatorChar);
			Directory.CreateDirectory (configFolderString);
		}

		[TestFixtureTearDown]
		public void DeleteConfigFolder ()
		{
			Directory.Delete (configFolderString);
		}

		[SetUp]
		public void CreateLibraryManager ()
		{
			testManager = new LibraryDatabaseManager (configFolderString);

			book = new Book();
			book.Title = "Sample Book";
			book.Author = "Sample Author";
			book.Genre = "Sample Genre";
			book.YearPublished = 1969;
			book.FilePath = "/home/books/ebooks/book.pdf";
		}

		[TearDown]
		public void DeleteLibraryManagerDatabase ()
		{
			File.Delete (LibraryDatabaseManager.DatabasePath);
		}

		[Test]
		public void CreateLibraryManagerTest ()
		{
			Assert.IsNotNull (testManager);
		}

		[Test]
		public void AddBookToLibraryTest ()
		{
			testManager.AddBook (book);
			Assert.IsNotEmpty (testManager.Books);
		}

		[Test]
		public void RetrieveKnownBookFromLibraryTest ()
		{
			testManager.AddBook (book);
			Book b = testManager.GetBook (0);
			Assert.IsTrue (b.Equals (book));
		}

		[Test]
		[ExpectedException ("Bookling.Controller.BookNotFoundException")]
		public void RetrieveUnknownBookFromLibraryTest ()
		{
			testManager.GetBook (0);
		}

		[Test]
		public void GetIndexOfKnownBookInLibraryTest ()
		{
			testManager.AddBook (book);
			Assert.IsTrue (testManager.GetBookIndex (book) == 0);
		}

		[Test]
		[ExpectedException ("Bookling.Controller.BookNotFoundException")]
		public void GetIndexOfUnkownBookInLibraryTest ()
		{
			testManager.GetBookIndex (book);
		}

		[Test]
		public void RemoveKnownBookFromLibraryByIndexTest ()
		{
			testManager.AddBook (book);
			testManager.RemoveBook (0);
			Assert.IsEmpty (testManager.Books);
		}

		[Test]
		[ExpectedException ("Bookling.Controller.BookNotFoundException")]
		public void RemoveUnknownBookFromLibraryByIndexTest ()
		{
			testManager.RemoveBook (0);
		}

		[Test]
		[ExpectedException ("Bookling.Controller.BookNotFoundException")]
		public void RemoveBookWithInvalidIndexTest ()
		{
			testManager.RemoveBook (-3);
		}

		[Test]
		public void RemoveKnownBookFromLibraryByReferenceTest ()
		{
			testManager.AddBook (book);
			testManager.RemoveBook (book);
			Assert.IsEmpty (testManager.Books);
		}

		[Test]
		[ExpectedException ("Bookling.Controller.BookNotFoundException")]
		public void RemoveUnknownBookFromLibraryByReferenceTest ()
		{
			testManager.RemoveBook (new Book ());
		}

		[Test]
		public void AlterKnownBookInLibraryTest ()
		{
			testManager.AddBook (book);
			Book b = new Book ();
			b.Title = "A Different Book";
			b.Author = "Other Author";
			b.Genre = "Horror";
			b.YearPublished = 1992;
			b.FilePath = "/home/docs/book.mobi";

			testManager.AlterBookData (0, b);
			Assert.IsTrue (testManager.GetBook (0).Equals (b));
		}

		[Test]
		[ExpectedException ("Bookling.Controller.BookNotFoundException")]
		public void AlterBookNotInLibraryTest ()
		{
			testManager.AlterBookData (0, book);
		}
	}
}

