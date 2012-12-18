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

namespace Bookling
{
	[TestFixture()]
	public class LibraryManagerTest
	{
		private LibraryManager testManager;
		private Book b;

		[SetUp]
		public void CreateLibraryManager ()
		{
			testManager = new LibraryManager ();

			b = new Book();
			b.Title = "Sample Book";
			b.Author = "Sample Author";
			b.Genre = "Sample Genre";
			b.YearPublished = 1969;
			b.FilePath = "/home/books/ebooks";
		}

		[TearDown]
		public void DeleteLibraryManagerDatabase ()
		{
			File.Delete (LibraryManager.DatabasePath);
		}

		[Test]
		public void CreateLibraryManagerTest ()
		{
			Assert.IsNotNull (testManager);
		}

		[Test]
		public void AddBookToLibraryTest ()
		{
			Assert.IsTrue (testManager.AddBook (b));
			Assert.IsNotNull (testManager.GetBook (0));
		}

		[Test]
		public void RemoveBookFromLibraryByIndexTest ()
		{
			testManager.AddBook (b);
			Assert.IsTrue (testManager.RemoveBook (0));
			Console.WriteLine (testManager.GetBook (0).Author);
			Assert.IsNull (testManager.GetBook (0));

		}

		[Test]
		public void RemoveBookFromLibraryByReferenceTest ()
		{
			testManager.AddBook (b);
			Assert.IsTrue (testManager.RemoveBook (b));
			Assert.IsFalse (testManager.RemoveBook (new Book()));
		}
	}
}

