using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var db = new ProductContext();
            IQueryable<Product> product = db.Products;
            if (productId.HasValue && productId > 0) 
            { 
                product = product.Where(p => p.ProductID == productId); 
            } 
            else 
            { 
                product = null; 
            }
            return product;
        }
    }
}