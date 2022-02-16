using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBookstore.Models
{
    public interface IAmazonBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
