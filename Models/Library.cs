using System;
using System.Collections.Generic;

namespace console_library.Models
{
  class Library
  {
    private List<Book> Books { get; set; }
    private List<Book> CheckedOut { get; set; }
    public Library()
    {
      Books = new List<Book>();
      CheckedOut = new List<Book>();
    }

    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {Books[i].Title} - {Books[i].Author}");
      }
    }
    public void PrintCheckedOut()
    {
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {CheckedOut[i].Title} - {CheckedOut[i].Author}");
      }
    }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }

    public void Checkout(string selection)
    {
      Book selectedBook = ValidateUserSelection(selection, Books);

      if (selectedBook == null)
      {
        Console.Clear();
        Console.WriteLine(@"Invalid Selection
        ");
        return;
      }

      selectedBook.Available = false;
      CheckedOut.Add(selectedBook);
      Books.Remove(selectedBook);
      Console.Clear();
      Console.WriteLine($"You have checked out {selectedBook.Author}");
    }

    public void ReturnBook(string selection)
    {
      Book selectedBook = ValidateUserSelection(selection, CheckedOut);

      if (selectedBook == null)
      {
        Console.WriteLine("Invalid Selection, please make a valid slection: ");
        return;
      }
      selectedBook.Available = true;
      Books.Add(selectedBook);
      CheckedOut.Remove(selectedBook);
      Console.Clear();
      Console.WriteLine("Successfully Returned Book!");
    }

    private Book ValidateUserSelection(string selection, List<Book> bookList)
    {
      int bookIndex = -1;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 0 || bookIndex > bookList.Count)
      {
        Console.Clear();
        Console.WriteLine("Please make a valid selection");
        return null;
      }
      return bookList[bookIndex - 1];
    }
  }
}