using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    public class CookbookRepo
    {
        private readonly List<Cookbook> Books = new List<Cookbook>();

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
    }
}
