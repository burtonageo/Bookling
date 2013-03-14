//
// LibraryFileManager.cs
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
using System.Xml;
using System.Xml.Schema;

namespace Bookling.Controller
{
	public class LibraryFileManager : IDisposable
	{
		#region Properties

		public string LibraryDirectory {
			get;
			set;
		}

		public String LibraryInfoFile {
			get;
			protected set;
		}

		private bool disposed;

		#endregion
		#region Constructors

		public LibraryFileManager (String infoFilePath, String libraryDirectory)
		{
			if (!Directory.Exists (infoFilePath)) {
				Directory.CreateDirectory (infoFilePath);
			}
			if (!Directory.Exists (libraryDirectory)) {
				Directory.CreateDirectory (libraryDirectory);
				LibraryDirectory = libraryDirectory;
			}
			LibraryInfoFile = String.Format (infoFilePath + "{0}config.xml", Path.DirectorySeparatorChar);
			if (!File.Exists (LibraryInfoFile)) {
				File.Create (LibraryInfoFile);
				XmlTextWriter configWriter = new XmlTextWriter (LibraryInfoFile, null);
				configWriter.WriteStartDocument ();
				configWriter.WriteStartElement ("Library");
				configWriter.WriteEndElement ();
				configWriter.WriteEndDocument ();
				configWriter.Close ();

			}
		}

		public LibraryFileManager (String libraryDirectory) : 
			this (LibraryManager.ConfigFolder, libraryDirectory)
		{

		}

		#endregion
		#region Destructors

		~LibraryFileManager ()
		{
			Dispose (false);
		}
		
		public void Dispose ()
		{
			Dispose (true);
			disposed = true;
			GC.SuppressFinalize (this);
		}
		
		protected void Dispose (bool freeManagedObjectsAlso)
		{
			if (!disposed) {
				if (freeManagedObjectsAlso) {

				}
			} else {
				throw new ObjectDisposedException (GetType ().FullName);
			}
		}

		#endregion
		#region Methods

		public void MoveBook (string fileSource)
		{
			if (!File.Exists(fileSource)) {
				throw new IOException("Book does not exist");
			}
			File.Move(fileSource, LibraryDirectory);
		}

		public void DeleteBook (string bookPath)
		{
			if (!File.Exists(bookPath)) {
				throw new BookNotFoundException();
			}
			File.Delete(bookPath);
		}

		public void Rescan ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

