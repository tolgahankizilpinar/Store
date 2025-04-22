using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public double Latitude  { get; set; } = 41.0082;  // default İstanbul Latitude
        public double Longitude { get; set; } = 28.9784;  // default İstanbul Longitude

        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Cart = cartService;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId, false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            return RedirectToPage(new {returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(x => x.Product.ProductId == id).Product);
            //HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}