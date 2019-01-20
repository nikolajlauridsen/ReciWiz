using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Persistence;

namespace RecipeLib.Domain
{
    public class CookbookRepo
    {
        private readonly List<Cookbook> Books = new List<Cookbook>();
        private readonly IDB db;

        public CookbookRepo()
        {
            Books.Add(new Cookbook("test"));
            db = new LiteConnector();
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

        public List<Dictionary<string, object>> GetBooksData()
        {
            List<Dictionary<string, object>> bookData = new List<Dictionary<string, object>>();
            foreach(Cookbook book in Books) {
                bookData.Add(book.GetContext());
            }
            return bookData;
        }
    }
}
