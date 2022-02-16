using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBookstore.Models
{
    public class EFAmazonBookstoreRepository : IAmazonBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFAmazonBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}

