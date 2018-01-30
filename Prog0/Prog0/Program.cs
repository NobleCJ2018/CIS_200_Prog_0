// Program 0
// File: Program.cs
// This file creates a simple test application class that creates
// an array of LibraryBook objects and tests them.

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


        //    LibraryBook[] theBooks = { book1, book2, book3, book4, book5 }; // Test array of books

        var theBooks = new List<LibraryBook>();
        theBooks.Add(book1);
        theBooks.Add(book2);
        theBooks.Add(book3);
        theBooks.Add(book4);
        theBooks.Add(book5);


        LibraryPatron patron1 = new LibraryPatron("The Mittani", "GSF001"); // Patron 1
        LibraryPatron patron2 = new LibraryPatron("Asher Elias", "GSF024"); // Patron 2
        LibraryPatron patron3 = new LibraryPatron("Jay Amazingness", "GSF1DQ"); // Patron 3



        WriteLine("Original list of books");
        WriteLine("----------------------");
        PrintBooks(theBooks);
        Pause();

        // Make changes
        book1.CheckOut(patron1); // 1st Check Out????
        book2.Publisher = "Borrowed Books";
        book3.CheckOut(patron2);
        book4.CallNumber = "AB123 4A";
        book5.CheckOut(patron3);
        book5.CopyrightYear = 2018; // Attempt invalid year
        book4.CheckOut(patron3);
        book2.CheckOut(patron2);

        WriteLine("After changes");
        WriteLine("-------------");
        PrintBooks(theBooks);


        Pause();


        WriteLine("Where Have All My Books Gone????");
        WriteLine("--------------------------------");

        BookInvCheck(theBooks);

        Pause();


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