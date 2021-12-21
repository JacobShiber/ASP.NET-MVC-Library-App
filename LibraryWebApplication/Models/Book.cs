using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApplication.Models
{
    public class Book
    {
        string bookName;
        string author;
        int releaseDate;
        int pageAmount;
        int bookId;
        public static int uniqueId = 0;

        public Book (string _bookName, string _author, int _releaseDate, int _pageAmount, int _bookId)
        {
            this.bookName = _bookName;
            this.author = _author;
            this.releaseDate = _releaseDate;
            this.pageAmount = _pageAmount;
            this.bookId = _bookId;
            uniqueId++;
        }

        public string BookName
        {
            get { return this.bookName; }
            set { this.bookName = value; }
        }

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public int ReleaseDate
        {
            get { return this.releaseDate; }
            set { this.releaseDate = value; }
        }

        public int PageAmount
        {
            get { return this.pageAmount; }
            set { this.pageAmount = value; }
        }

        public int BookId
        {
            get { return this.bookId; }
            set { this.bookId = value; }
        }
    }
}