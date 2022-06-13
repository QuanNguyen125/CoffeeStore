using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeStore.MyTagHelper;
using CoffeeStore.Models;
using System.Linq;

namespace CoffeeStore.Pages
{
    public class MyCartModel : PageModel
    {
        private ICoffeeStoreRepository repository;
        public MyCartModel(ICoffeeStoreRepository repo)
        {
            repository = repo;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
        }
        public IActionResult OnPost(long coffeeId, string returnUrl)
        {
            Coffee coffee = repository.Coffees
            .FirstOrDefault(b => b.CoffeeID == coffeeId);
            myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
            myCart.AddItem(coffee, 1);
            HttpContext.Session.SetJson("mycart", myCart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}