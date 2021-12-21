using LibraryWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApplication.Controllers.API
{
    public class BooksController : Controller
    {
        List<Book> booksList = new List<Book>();
        
        // GET: Books
        public ActionResult Index()
        {
            AddBooksToList();
            return Json(booksList, JsonRequestBehavior.AllowGet);
        }


        // GET: Books/GetById/5
        public ActionResult GetById(int id)
        {
            AddBooksToList();
            for (int i = 0; i < booksList.Count; i++)
            {
                if (booksList[i].BookId == id) return Json(booksList[i], JsonRequestBehavior.AllowGet);
            }

            return Json(new { Massage = "No book been found" }, JsonRequestBehavior.AllowGet);
        }


        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Book newBook = new Book(collection["bookName"], collection["author"], int.Parse(collection["releaseDate"]), int.Parse(collection["pageAmount"]), Book.uniqueId);
                booksList.Add(newBook);
                return Json(new {Massage = "Book Added"}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Massage = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }


        // POST: Books/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, FormCollection collection)
        {
                for(int i = 0; i < booksList.Count; i++)
                {
                    if(booksList[i].BookId == id)
                    {
                        booksList[i].BookName = collection["bookName"];
                        booksList[i].Author = collection["author"];
                        booksList[i].ReleaseDate = int.Parse(collection["releaseDate"]);
                        booksList[i].PageAmount = int.Parse(collection["pageAmount"]);

                        return Json(new { Massage = "Book Edit succesfully" }, JsonRequestBehavior.AllowGet);
                    }
                }
            return Json(new { Massage = "Error" }, JsonRequestBehavior.AllowGet);
        }


        // POST: Books/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            for(int i = 0; i < booksList.Count; i++)
            {
                if (booksList[i].BookId == id)
                {
                    booksList.RemoveAt(i);
                    return Json(new { Massage = "Book Deleted" }, JsonRequestBehavior.AllowGet);
                }    
            }
            return Json(new { Massage = "Error" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByName(string name)
        {
            IEnumerable<Book> booksNames = from book in booksList
                                            where book.BookName.ToLower() == name.ToLower()
                                            select book;
            IEnumerable<Book> sortedList = booksNames.OrderBy(book => book.ReleaseDate).ToList();
            return Json(sortedList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByAuthor(string author)
        {
            IEnumerable<Book> booksNames = from book in booksList
                                           where book.Author.ToLower() == author.ToLower()
                                           select book;
            IEnumerable<Book> sortedList = booksNames.OrderBy(book => book.ReleaseDate).ToList();
            return Json(sortedList, JsonRequestBehavior.AllowGet);
        }

        public void AddBooksToList()
        {
            Random ran = new Random();

            booksList.Add(new Book("The Calling", "Steph", 2015, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("Summer", "John", 2009, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("Black Holes", "Tommy", 2001, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("The Rain", "J.K", 2018, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("Secrets", "Anthon", 2015, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("Blood & Bones", "J.K", 2014, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("Rage", "John", 2021, ran.Next(100, 500), Book.uniqueId));
            booksList.Add(new Book("The Fog", "Hannah", 2016, ran.Next(100, 500), Book.uniqueId));
        }
    }
}
