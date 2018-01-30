/*
Grading_ID:****: 
Program********: 0
Due_Date*******: 29 JAN 2018
Section********: CIS 200 01
*/

// File: LibraryBook.cs
// This file creates a simple LibraryBook class capable of tracking
// the book's title, author, publisher, copyright year, call number,
// and checked out status.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.String; 


public class LibraryBook
{
    public const int DEFAULT_YEAR = 2017; // Default copyright year

    private string _title;      // The book's title
    private string _author;     // The book's author
    private string _publisher;  // The book's publisher
    private int _copyrightYear; // The book's year of copyright
    private string _callNumber; // The book's call number in the library
    private bool _checkedOut;   // The book's checked out status
    private LibraryPatron PatronID { get; set; }  // The HAS-A Relationship, Auto Imp.

    // Precondition:  theCopyrightYear >= 0
    // Postcondition: The library book has been initialized with the specified
    //                values for title, author, publisher, copyright year, and
    //                call number. The book is not checked out.
    //                When Checked out, a library patron will be related to the book object


    // Constructor: Requires 6 parameters, the 6th being the Patron checking out the book
    //              Patron is null as instance creation

    public LibraryBook(String theTitle, String theAuthor, String thePublisher,
        int theCopyrightYear, String theCallNumber, LibraryPatron thePatron)
    {
        Title = theTitle;
        Author = theAuthor;
        Publisher = thePublisher;
        CopyrightYear = theCopyrightYear;
        CallNumber = theCallNumber;
        PatronID = thePatron;


        ReturnToShelf(); // Make sure book is not checked out
    }

    public LibraryPatron Patron 
    {
        // Precondition: The book must be checked out before returning a patron
        // Postcondition: The patron has been returned if check out true, returns null if false
        get
        {
            if (_checkedOut)
            {
                return PatronID;
            }


            return null;

        }
    }

    public string Title
    {
        // Precondition:  None
        // Postcondition: The title has been returned
        get
        {
            return _title;
        }

        // Precondition:  None
        // Postcondition: The title has been set to the specified value
        set
        {
            if (IsNullOrWhiteSpace(value.Trim()))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Title)} Please Enter A Title");
            }
            _title = value;
        }
    }

    public string Author
    {
        // Precondition:  None
        // Postcondition: The author has been returned
        get
        {
            return _author;
        }

        // Precondition:  None
        // Postcondition: The author has been set to the specified value
        set
        {
            _author = value;
        }
    }

    public string Publisher
    {
        // Precondition:  None
        // Postcondition: The publisher has been returned
        get
        {
            return _publisher;
        }

        // Precondition:  None
        // Postcondition: The publisher has been set to the specified value
        set
        {
            _publisher = value;
        }
    }

    public int CopyrightYear
    {
        // Precondition:  None
        // Postcondition: The copyright year has been returned
        get
        {
            return _copyrightYear;
        }

        // Precondition:  value >= 0
        // Postcondition: The copyright year has been set to the specified value
        set
        {
            if (value >= 0)
                _copyrightYear = value;
            else
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(CopyrightYear)}, Please Enter A Copyright Year");
        }
    }

    public string CallNumber
    {
        // Precondition:  None
        // Postcondition: The call number has been returned
        get
        {
            return _callNumber;
        }

        // Precondition:  None
        // Postcondition: The call number has been set to the specified value
        set
        {
            if (IsNullOrWhiteSpace(value.Trim()))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(CallNumber)} Please Enter A Call Number");
            }
            _callNumber = value;
        }
    }


    // Precondition:  None
    // Postcondition: The book is checked out & A patron object is ref to this book
    public void CheckOut(LibraryPatron a) 
    {
        PatronID = a;
        _checkedOut = true;
    }

    // Precondition:  None
    // Postcondition: The book is not checked out & patron is set to null
    public void ReturnToShelf()
    {
        PatronID = null;
        _checkedOut = false;
    }

        // Precondition:  None
        // Postcondition: true is returned if the book is checked out,
        //                otherwise false is returned
        public bool IsCheckedOut()
    {

        return _checkedOut;
    }

    // Precondition:  None
    // Postcondition: A string is returned representing the libary book's
    //                data on separate lines
    public override string ToString()
    {
        string NL = Environment.NewLine; // Newline shortcut
        string IsYouGotAPatron;     // var for conditional check out status

        if (_checkedOut)
        {
            IsYouGotAPatron = $"Check Out By:{NL}{PatronID}";
        }
        else
            IsYouGotAPatron = $"Not Checked Out";

        return
            $"Title: {Title}{NL}" +
            $"Author: {Author}{NL}" +
            $"Publisher: {Publisher}{NL}" +
            $"Copyright: {CopyrightYear}{NL}" +
            $"Call Number: {CallNumber}{NL}" +
            $"{IsYouGotAPatron}";

    }
}