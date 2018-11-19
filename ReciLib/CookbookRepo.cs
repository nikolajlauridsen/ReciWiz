using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    class CookbookRepo
    {
        private readonly List<Cookbook> books = new List<Cookbook>();

        public Cookbook GetBook(string name)
        {
            foreach(Cookbook book in books)
            {
                if(book.Name == name)
                {
                    return book;
                }
            }
            return null;
        }
    }
}
