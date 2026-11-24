using System;

namespace ProductRatingSystem.Entity
{
    // Subsystem: Entity
    // Associations: ProductList contains many Product objects
    //               (aggregation).
    public class ProductList
    {
        public Product[] products;

        public ProductList(Product[] mproducts)
        {
            if (mproducts != null)
            {
                products = mproducts;
            }
            else
            {
                products = new Product[0];
            }
        }

        public int getCount()
        {
            return products.Length;
        }

        public Product getProduct(int mindex)
        {
            if (mindex > -1 && mindex < products.Length)
            {
                return products[mindex];
            }
            return null;
        }
    }

}
