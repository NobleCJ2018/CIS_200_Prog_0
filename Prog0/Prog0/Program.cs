/*
Grading_ID:****: 
Program********: 0
Due_Date*******: 29 JAN 2018
Section********: CIS 200 01
*/

// File: Program.cs
// This file creates a simple test application class that creates
// an array of LibraryBook objects and tests them.


// Life is a circle...... so why not code that bois

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;



public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryBook class has been tested
    public static void Main(string[] args)
    {
        // Let's Make some books
        LibraryBook book1 = new LibraryBook("The Wright Guide to C#", "Andrew Wright", "UofL Press",
            2010, "ZZ25 3G", null);  // 1st test book
        LibraryBook book2 = new LibraryBook("Harriet Pooter", "IP Thief", "Stealer Books",
            2000, "AG773 ZF", null); // 2nd test book
        LibraryBook book3 = new LibraryBook("The Color Mauve", "Mary Smith", "Beautiful Books Ltd.",
            1985, "JJ438 4T", null); // 3rd test book
        LibraryBook book4 = new LibraryBook("The Guan Guide to SQL", "Jeff Guan", "UofL Press",
            2016, "ZZ24 4F", null);    // 4th test book
        LibraryBook book5 = new LibraryBook("The Big Book of Doughnuts", "Homer Simpson", "Doh Books",
            2001, "AE842 7A", null); // 5th test book

        //    Comment out array to be replace with List<>
        //    LibraryBook[] theBooks = { book1, book2, book3, book4, book5 }; // Test array of books

        var theBooks = new List<LibraryBook>(); // Make a new List<> of LibraryBooks
        theBooks.Add(book1);    // Add Book1
        theBooks.Add(book2);    // Add Book2
        theBooks.Add(book3);    // Add Book3
        theBooks.Add(book4);    // Add Book4
        theBooks.Add(book5);    // Add Book5


        LibraryPatron patron1 = new LibraryPatron("The Mittani", "GSF001");     // Patron 1
        LibraryPatron patron2 = new LibraryPatron("Asher Elias", "GSF024");     // Patron 2
        LibraryPatron patron3 = new LibraryPatron("Jay Amazingness", "GSF1DQ"); // Patron 3


        // List all My Books
        WriteLine("Original list of books");
        WriteLine("----------------------");
        PrintBooks(theBooks);
        Pause();

        // Make changes
        book1.CheckOut(patron1);             // A check out with patron passed
        book2.Publisher = "Borrowed Books";  // keep change
        book3.CheckOut(patron2);             // A check out the patron passed
        book4.CallNumber = "AB123 4A";       // keep change
        book5.CheckOut(patron3);             // A check out the patron passed
        book5.CopyrightYear = 2018;          // Attempt invalid year
        book4.CheckOut(patron3);             // A check out the patron passed
        book2.CheckOut(patron2);             // A check out the patron passed

        // List all my books after changes
        WriteLine("After changes");
        WriteLine("-------------");
        PrintBooks(theBooks);


        Pause();

        // Using the LibraryBook.Patron read only property. 
        WriteLine("List Books Via the Read Only Patron Property");
        WriteLine("----------------------------------------------");
        WriteLine($"Book Call Number: {book1.CallNumber}");
        WriteLine($"{book1.Patron}");
        WriteLine();
        WriteLine($"Book Call Number: {book2.CallNumber}");
        WriteLine($"{book2.Patron}");
        WriteLine();
        WriteLine($"Book Call Number: {book3.CallNumber}");
        WriteLine($"{book3.Patron}");
        WriteLine();
        WriteLine($"Book Call Number: {book4.CallNumber}");
        WriteLine($"{book4.Patron}");
        WriteLine();
        WriteLine($"Book Call Number: {book5.CallNumber}");
        WriteLine($"{book5.Patron}");
        WriteLine();

        Pause();

        // I want to know status of all my books
        WriteLine("Where Have All My Books Gone????");
        WriteLine("--------------------------------");

        BookInvCheck(theBooks);     // New Method, outputs status based on checked out

        Pause();

        // outputs books based on the check out status
        WriteLine("Some Books are Returned. Whats Out Right Now?");
        WriteLine("---------------------------------------------");

        book2.ReturnToShelf();
        book5.ReturnToShelf();

        BookInvCheck(theBooks);

        Pause();


        // Return the books
        book1.ReturnToShelf();
        book2.ReturnToShelf();
        book3.ReturnToShelf();
        book4.ReturnToShelf();
        book5.ReturnToShelf();


        WriteLine("After returning the books");
        WriteLine("-------------------------");
        PrintBooks(theBooks);
    }

    // Precondition:  None
    // Postcondition: The books have been printed to the console
    public static void PrintBooks(List<LibraryBook> theBooks)
    {
        foreach (LibraryBook b in theBooks)
        {
            Console.WriteLine(b);
            Console.WriteLine();
        }
    }

    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
    public static void BookInvCheck(List<LibraryBook> theBooks)
    {
        foreach (LibraryBook b in theBooks)
        {
            bool test;
            test = b.IsCheckedOut();
            if (!test)
            {
                WriteLine($"Book Call: {b.CallNumber}");
                WriteLine("Status: Returned");
                WriteLine();
            }
            else
            {
                WriteLine($"Book Call: {b.CallNumber}");
                WriteLine($"Status: Checked Out");
                WriteLine(b.Patron);
                WriteLine();
            }

        }
    }
}
