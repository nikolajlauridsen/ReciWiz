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
            db = new LiteConnector();

            foreach(Dictionary<string, object> bookData in db.GetCookBooks()) {
                CreateCookBook((string)bookData["title"], (string)bookData["author"], (int)bookData["id"]);
            }
        }

        public Cookbook GetBook(string name)
        {
            foreach(Cookbook book in Books)
            {
                if(book.Title == name)
                {
                    return book;
                }
            }
            return null;
        }

        public void CreateCookBook(string name, string author)
        {
            int bookID = db.CreateCookbook(name, author);
            CreateCookBook(name, author, bookID);
        }

        private void CreateCookBook(string name, string author, int id)
        {
            Cookbook book = new Cookbook(name, author, id);
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
