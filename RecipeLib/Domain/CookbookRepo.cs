using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Persistence;
using RecipeLib.Model;

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

        public List<ICookbook> GetBooks() {
            List <ICookbook> berks = new List<ICookbook>();
            foreach(ICookbook book in Books) {
                berks.Add(book);
            }

            return berks;
        }

        public Cookbook GetBook(string name)
        {
            foreach(Cookbook book in Books)
            {
                if(book.Title.Equals(name))
                {
                    return book;
                }
            }
            return null;
        }

        public Cookbook GetBook(int id)
        {
            foreach(Cookbook book in Books) {
                if(book.ID == id) {
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

    }
}
