//
// LibraryController.cs
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
using Bookling.Models;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.IO;

namespace Bookling.Controller
{
	public class LibraryManager
	{
		public static String DatabaseDirectory 
		{
			get {
				return String.Format (
					Environment.GetFolderPath (
					Environment.SpecialFolder.ApplicationData) +
					"{0}Bookling", Path.DirectorySeparatorChar);
			}
		}

		public static String DatabasePath 
		{
			get {
				return String.Format (DatabaseDirectory + "{0}Library.db", 
						Path.DirectorySeparatorChar);
			}
		}

		public int MaxId 
		{
			get {
				int max = 0;	
				try {
					SqliteCommand command = Connection.CreateCommand ();
					command.CommandText = "SELECT COALESCE(MAX(BookID)+1, 0) FROM Books";

					SqliteDataReader reader = command.ExecuteReader();
					while(reader.Read ()) {
						max = reader.GetInt32(0);
					}
				} catch (SqliteException e) {
					throw new SqliteException (e.Message);
				}
				return max;
			}
		}

		public int DatabaseSize {
			get {
				return Books.Count;
			}
		}

		public ArrayList Books {
			get {
				ArrayList bookList = new ArrayList();
				try {
					SqliteCommand command = Connection.CreateCommand ();
					command.CommandText = "SELECT BookTitle, BookAuthor, " +
						"BookGenre, BookPublishedYear, BookPath FROM Books";

					SqliteDataReader reader = command.ExecuteReader ();
					while (reader.Read ()) {
						Book b = new Book ();
						b.Title = reader.GetString (0);
						b.Author = reader.GetString (1);
						b.Genre = reader.GetString (2);
						b.YearPublished = reader.GetInt32 (3);
						b.Author = reader.GetString (4);
						bookList.Add (b);
					}
				} catch (SqliteException e) {
					throw new SqliteException (e.Message);
				}
				return bookList;
			}
		}

		private SqliteConnection Connection;

		public LibraryManager ()
		{
			Connection = new SqliteConnection (
				"Data Source = " + LibraryManager.DatabasePath + 
				"; Version = 3;");

			if (!Directory.Exists (LibraryManager.DatabaseDirectory)) {
				Directory.CreateDirectory (LibraryManager.DatabaseDirectory);
			}

			bool exists = File.Exists (LibraryManager.DatabasePath);
			if (!exists) {
				SqliteConnection.CreateFile (LibraryManager.DatabasePath);
			}

			Connection.Open ();
			if (!exists) {
				using (SqliteCommand command = new SqliteCommand (Connection)) {
					command.CommandText = 
						"CREATE TABLE Books (BookID INTEGER PRIMARY KEY, " +
						"BookTitle TEXT, BookAuthor TEXT, BookGenre TEXT, " +
						"BookPublishedYear INTEGER, BookPath TEXT);"; 
					command.ExecuteNonQuery();
				}
			}
		}

		~LibraryManager ()
		{
			Connection.Close ();
		}

		public void AddBook (Book book)
		{			
			try {			
				using (SqliteCommand command = new SqliteCommand (Connection)) {
					command.CommandText = 
						"INSERT INTO Books " +
						"(BookID, BookTitle, BookAuthor, " +
						"BookGenre, BookPublishedYear, BookPath) " +
						"VALUES (:id, :title, :author, :genre, :year, :path);";

					command.Parameters.AddWithValue (":id", MaxId); 
					command.Parameters.AddWithValue (":title", book.Title); 
					command.Parameters.AddWithValue (":author", book.Author);
					command.Parameters.AddWithValue (":genre", book.Genre);
					command.Parameters.AddWithValue (":year", book.YearPublished);
					command.Parameters.AddWithValue (":path", book.FilePath);
					command.ExecuteNonQuery ();
				}
			} catch (SqliteException e) {
				throw new SqliteException (e.Message);
			}
		}

		public Book GetBook (int index)
		{
			if (index < 0) {
				throw new BookNotFoundException ();
			}

			Book b = new Book ();

			using (SqliteCommand command = new SqliteCommand (Connection)) {
				command.CommandText = 
					"SELECT BookTitle, BookAuthor, " +
					"BookGenre, BookPublishedYear, BookPath " +
					"FROM Books WHERE BookID = " + index + ";";
			
				SqliteDataReader reader = command.ExecuteReader ();
				if (reader.HasRows == false) {
					throw new BookNotFoundException ();
				}
				while (reader.Read ()) {
					b.Title = reader.GetString (0);
					b.Author = reader.GetString (1);
					b.Genre = reader.GetString (2);
					b.YearPublished = reader.GetInt32 (3);
					b.FilePath = reader.GetString (4);
				}
			}
			return b;
		}

		public void RemoveBook (Book book)
		{
			try {
				using (SqliteCommand command = new SqliteCommand (Connection)) {
					command.CommandText =
						"DELETE FROM Books WHERE " +
						"BookTitle = :title AND " +
						"BookAuthor = :author AND " +
						"BookGenre = :genre AND " +
						"BookPath = :path AND " +
						"BookPublishedYear = :year;";
					command.Parameters.AddWithValue (":title", book.Title); 
					command.Parameters.AddWithValue (":author", book.Author);
					command.Parameters.AddWithValue (":genre", book.Genre);
					command.Parameters.AddWithValue (":year", book.YearPublished);
					command.Parameters.AddWithValue (":path", book.FilePath);
					command.ExecuteNonQuery ();
				}
			} catch (SqliteException e) {
				throw new SqliteException (e.Message);
			}
		}

		public void RemoveBook (int bookID) 
		{
			try {
				using (SqliteCommand command = new SqliteCommand (Connection)) {
					command.CommandText = "DELETE FROM Books WHERE BookID = :id;";
					command.Parameters.Add (new SqliteParameter (":id", bookID));
					command.ExecuteNonQuery ();
				}
			} catch (SqliteException e) {
				throw new SqliteException (e.Message);
			}
		}

		public void AlterBookData (int bookID, Book book)
		{
			
			try {
				using (SqliteCommand command = new SqliteCommand (Connection)) {
					command.CommandText =
						"UPDATE Books SET " +
						"BookTitle = :title, " +
						"BookAuthor = :author, " +
						"BookPublishedYear = :year, " +
						"BookPath = :path " +
						"WHERE BookID = :id;";
					command.Parameters.AddWithValue (":title", book.Title); 
					command.Parameters.AddWithValue (":author", book.Author);
					command.Parameters.AddWithValue (":genre", book.Genre);
					command.Parameters.AddWithValue (":year", book.YearPublished);
					command.Parameters.AddWithValue (":path", book.FilePath);
					command.Parameters.AddWithValue (":id", bookID); 
					command.ExecuteNonQuery ();
				}
			} catch (SqliteException e) {
				throw new SqliteException (e.Message);
			}
		} 
	}
}

