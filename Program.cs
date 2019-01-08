using System;
using console_library.Models;

namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      bool inLirary = true;
      Console.Clear();
      Book whereTheSidewalkEnds = new Book("Shel Silverstein", "Where the Sidewalk Ends");
      Book theHobbit = new Book("J.R.R. Tolkien", "The Hobbit");
      Book theLionTheWitchAndTheWardrobe = new Book("C.S. Lewis", "The Lion, the Witch, and the Wardrobe");
      Book hpAndTheSorcerersStone = new Book("J.K. Rowling", "Harry Pottor and the Sorcerer's Stone");
      Library library = new Library();
      library.AddBook(whereTheSidewalkEnds);
      library.AddBook(theHobbit);
      library.AddBook(theLionTheWitchAndTheWardrobe);
      library.AddBook(hpAndTheSorcerersStone);

      Enum activeMenu = Menus.CheckoutBooks;

      while (inLirary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBooks:
            library.PrintBooks();
            break;
          case Menus.ReturnBooks:
            library.PrintCheckedOut();
            break;
        }
        string selection = Console.ReadLine();
        switch (selection)
        {
          case "return":
            Console.Clear();
            activeMenu = Menus.ReturnBooks;
            break;
          case "available":
            Console.Clear();
            activeMenu = Menus.CheckoutBooks;
            break;
          case "quit":
            inLirary = false;
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBooks))
            {
              library.Checkout(selection);
            }
            else
            {
              library.ReturnBook(selection);
            }
            break;
        }
      }
    }

    public enum Menus
    {
      CheckoutBooks,
      ReturnBooks
    }
  }
}
