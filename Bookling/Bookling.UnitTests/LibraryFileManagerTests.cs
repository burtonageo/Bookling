//
// LibraryFileManagerTests.cs
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
	public class LibraryFileManagerTests
	{
		#region Properties

		private LibraryFileManager fileManager;
		private String testFolderString;
		private String configFolderString;
		private Book book;

		#endregion
		#region Test Preparation

		[TestFixtureSetUp]
		public void CreateLibraryFileManagerFolders ()
		{
			testFolderString = String.Format (Environment.GetFolderPath (
				Environment.SpecialFolder.MyDocuments) + "{0}Bookling-Tests",
			                                  Path.DirectorySeparatorChar);
			configFolderString = String.Format (testFolderString +
			                                    "{0}File-Tests", Path.DirectorySeparatorChar);
			Directory.CreateDirectory (testFolderString);
			Directory.CreateDirectory (configFolderString);
		}

		[TestFixtureTearDown]
		public void DeleteLibraryFileManagerFolders ()
		{
			Directory.Delete (configFolderString);
			Directory.Delete (testFolderString);
		}

		[SetUp]
		public void CreateLibraryFileManager ()
		{
			fileManager = new LibraryFileManager (configFolderString);
		}

		[TearDown]
		public void DeleteConfigFile ()
		{
			File.Delete (fileManager.LibraryInfoFile);
		}

		#endregion
		#region Tests

		[Test]
		public void CreateLibraryFileManagerTest ()
		{
			Assert.IsNotNull (fileManager);
		}

		#endregion
	}
}

