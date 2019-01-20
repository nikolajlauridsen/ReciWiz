using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Domain
{
    public class CookbookRepo
    {
        private readonly List<Cookbook> Books = new List<Cookbook>();

        public CookbookRepo()
        {
            Books.Add(new Cookbook("test"));
        }

        public Cookbook GetBook(string name)
        {
            foreach(Cookbook book in Books)
            {
                if(book.Name == name)
                {
                    return book;
                }
            }
            return null;
        }

        public void CreateCookBook(string name)
        {
            Cookbook book = new Cookbook(name);
            Books.Add(book);
        }

        public List<string> GetBooksData()
        {
            List<string> bookData = new List<string>();
            foreach(Cookbook book in Books) {
                bookData.Add(book.Name);
            }
            return bookData;
        }
    }
}
