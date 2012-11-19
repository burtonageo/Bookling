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
using System.Data;
using System.IO;

namespace Bookling
{
	public class LibraryController
	{
		public string DataBasePath 
		{
			get {
				return String.Format (
					Environment.GetFolderPath (
					Environment.SpecialFolder.ApplicationData) +
					"{0}Bookling{0}Library.db", Path.DirectorySeparatorChar);
			}
		}

		public int MaxId {
			get {
				int max = 0;

				SqliteCommand command = Connection.CreateCommand ();
				string sql = "SELECT COALESCE(MAX(BookId)+1, 0) FROM Books";
				command.CommandText = sql;
				
				SqliteDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					max = reader.GetInt32(0);
				}

				command.Dispose();
				command = null;
				reader.Close();
				reader = null;

				return max;
			}
		}

		private SqliteConnection Connection;

		public LibraryController ()
		{
			Connection = new SqliteConnection (
				"URI=file:" + DataBasePath);

			bool exists = File.Exists (DataBasePath);
			if (exists == false) {
				SqliteConnection.CreateFile (DataBasePath);
			}

			Connection.Open ();

			if (!exists) {
				var creationCommands = new[]{
					"CREATE TABLE Books (BookID INTEGER PRIMARY KEY, " +
					"BookTitle TEXT, BookAuthor TEXT, " +
					"BookPublishedYear INTEGER, BookUri TEXT);"
				};
	
				foreach (var command in creationCommands) {
					using (SqliteCommand c = Connection.CreateCommand ()) {
						c.CommandText = command;
						c.ExecuteNonQuery ();
					}
				}
			}
		}

		~LibraryController ()
		{
			if (Connection != null && 
				Connection.State != ConnectionState.Closed) {
				Connection.Close ();
				Connection.Dispose();
				Connection = null;
			}
		}

		public bool AddBook (Book book)
		{
			try {
				using (SqliteCommand command = new SqliteCommand(Connection)) {
					command.CommandText =
						"INSERT INTO Books (BookID, BookTitle, BookAuthor, " +
							"BookPublishedYear, BookUri) VALUES (" +
							":id, ':title', ':author', ':year', :'uri'" +
							")";
					command.Parameters.Add (new SqliteParameter ("title", book.Title)); 
					command.Parameters.Add (new SqliteParameter ("author", book.Author)); 
					command.Parameters.Add (new SqliteParameter ("year", book.YearPublished));
					command.Parameters.Add (new SqliteParameter ("uri", book.FileURI));
					command.Parameters.Add (new SqliteParameter ("id", book.BookId));
					command.ExecuteNonQuery ();
				}
				return true;
			} catch (SqliteException e) {
				Console.WriteLine(e.Message);
				return false;
			}
		}

		public void PrintLibrary ()
		{
			SqliteCommand command = Connection.CreateCommand ();
			string sql =
				"SELECT BookTitle, BookAuthor " +
					"FROM Books";
			command.CommandText = sql;

			SqliteDataReader reader = command.ExecuteReader ();
			while(reader.Read()) {
				string title = reader.GetString (0);
				string author = reader.GetString (1);
				Console.WriteLine ("Book: " +
				                  title + " by " + author);
			}

			command.Dispose();
			command = null;
			reader.Close ();
			reader = null;
		}

		public bool RemoveBook (Book book) 
		{
			try {
				using (SqliteCommand command = new SqliteCommand(Connection)) {
					command.CommandText =
						"DELETE FROM Books WHERE " +
							"BookID = :id AND BookTitle = :title AND " +
							"BookAuthor = :author AND BookPublishedYear = :year AND " +
							"BookUri = :uri";
					command.Parameters.Add (new SqliteParameter ("id", book.BookId));
					command.Parameters.Add (new SqliteParameter ("title", book.Title)); 
					command.Parameters.Add (new SqliteParameter ("author", book.Author)); 
					command.Parameters.Add (new SqliteParameter ("year", book.YearPublished));
					command.Parameters.Add (new SqliteParameter ("uri", book.FileURI));
					command.ExecuteNonQuery ();
					}
				return true;
			} catch (SqliteException e) {
				Console.WriteLine(e.Message);
				return false;
			}
		}

		public bool RemoveBook (int bookID) 
		{
			try {
				using (SqliteCommand command = new SqliteCommand(Connection)) {
					command.CommandText =
						"DELETE FROM Books " +
							"WHERE BookID = :id;";
					command.Parameters.Add (new SqliteParameter ("id", bookID));
					command.ExecuteNonQuery ();
					}
					return true;
				} catch (SqliteException e) {
					Console.WriteLine(e.Message);
					return false;
				}
			}


		public bool AlterBookData (int bookID, Book book)
		{
			try {
				using (SqliteCommand command = new SqliteCommand(Connection)) {
					command.CommandText =
					"UPDATE Books SET " +
						"BookTitle = :title, BookAuthor = :author, " +
						"BookPublishedYear = :year, BookUri = :uri " +
						"WHERE BookID = :id;";
					command.Parameters.Add (new SqliteParameter ("title", book.Title)); 
					command.Parameters.Add (new SqliteParameter ("author", book.Author)); 
					command.Parameters.Add (new SqliteParameter ("year", book.YearPublished));
					command.Parameters.Add (new SqliteParameter ("uri", book.FileURI));
					command.Parameters.Add (new SqliteParameter ("id", bookID));
					command.ExecuteNonQuery ();
				}
				return true;
			} catch (SqliteException e) {
				Console.WriteLine(e.Message);
				return false;
			}
		}
	}
}

