using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;

namespace WingtipToys.Logic
{
    public class ShoppingCartActions
    {
        public string ShoppingCartId { get; set; }
        private ProductContext db = new ProductContext();
        public const string CartSessionKey = "CartId";
        public void AddToCart(int id)
        {
            ShoppingCartId = GetCartId();
            var cartItem = db.ShoppingCartItems.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == id);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    CartId = ShoppingCartId,
                    Quantity = 1,
                    DateCreated = DateTime.Now,
                    ProductId = id,
                    Product = db.Products.SingleOrDefault(p=>p.ProductID==id)
                };
            }
        }
        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }
        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();
            return db.ShoppingCartItems.Where(c => c.CartId == ShoppingCartId).ToList();
        }
    }
}
