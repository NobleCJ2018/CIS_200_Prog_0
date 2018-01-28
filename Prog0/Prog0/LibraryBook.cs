// Program 4
// CIS 199-01/-75
// Due: 12/5/2017
// By: Andrew L. Wright

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
    public LibraryPatron _patronName;  // The books's Patron Name
    public LibraryPatron _patronID;    // The book's Patron ID

    // Precondition:  theCopyrightYear >= 0
    // Postcondition: The library book has been initialized with the specified
    //                values for title, author, publisher, copyright year, and
    //                call number. The book is not checked out.

    public LibraryBook(String theTitle, String theAuthor, String thePublisher,
        int theCopyrightYear, String theCallNumber, LibraryPatron patronName, LibraryPatron patronID)
    {
        Title = theTitle;
        Author = theAuthor;
        Publisher = thePublisher;
        CopyrightYear = theCopyrightYear;
        CallNumber = theCallNumber;
        PatronName = patronName;
        PatronID = patronID;
        

        ReturnToShelf(); // Make sure book is not checked out
    }
    
    public LibraryPatron PatronName 
    {
        // Precondition:  None
        // Postcondition: The Patron Name has been returned
        get
        {
            return _patronName;
        }

        set
        {
            _patronName = value;
        }
    }
    
    public LibraryPatron PatronID
    {
        // Precondition:  None
        // Postcondition: The Patron ID has been returned
        get
        {
            return _patronID;
        }

        set
        {
            _patronID = value;
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
    // Postcondition: The book is checked out
    public void CheckOut()
    {
        _checkedOut = true;
    }

    // Precondition:  None
    // Postcondition: The book is not checked out
    public void ReturnToShelf()
    {
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

        return $"Title: {Title}{NL}Author: {Author}{NL}Publisher: {Publisher}{NL}" +
            $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}" +
            $"Checked Out: {IsCheckedOut()}";
    }
}
