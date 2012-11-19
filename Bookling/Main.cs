using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Bookling
{
	class MainClass
	{
		static void Main (string[] args)
		{
			NSApplication.Init ();
			NSApplication.Main (args);

			/*
			Bookling.LibraryController controller = new LibraryController();

			Bookling.Models.Book book1;
			book1.Author="Your Momma";
			book1.Title="Is So Thin";
			book1.FileURI="ThatSheFitsInAUSBPort.pdf";
			book1.YearPublished=1989;
			book1.BookId=0;

			//controller.AddBook(book1);

			Bookling.Models.Book book2;
			book2.Author="My Dad";
			book2.Title="Is Stronger Than Yours";
			book2.FileURI="BecauseHeCanLift80KiloWeights.pdf";
			book2.YearPublished=2011;
			book2.BookId=1;

			Bookling.Models.Book book3;
			book3.Author="My Bro";
			book3.Title="Smells";
			book3.FileURI="OfSomething.pdf";
			book3.YearPublished=2011;
			book3.BookId=1;
			


			//controller.AddBook(book2);
			controller.PrintLibrary();

			controller.AlterBookData(0, book2);
			controller.PrintLibrary();

			//Console.WriteLine(controller.MaxId);
			*/
		}
	}
}	

