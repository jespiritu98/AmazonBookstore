using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonBookstore.Infastructure;
using AmazonBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonBookstore.Pages
{
    public class AddToCartModel : PageModel
    {
        private IAmazonBookstoreRepository repo { get; set; }

        public AddToCartModel(IAmazonBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

           
            basket.AddItem(b, 1);
            
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage ( new {ReturnUrl = returnUrl});
        }
    }
}
