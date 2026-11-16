using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRatingSystem.Entity
{
    // Subsystem: Entity
    // Associations: Product -> UserAccount (seller, 1) through userID;
    //               a ProductList contains many Product objects;
    //               a ProductRating refers to one Product.
    public class Product
    {
        private int productID;
        private int userID;
        private string title;
        private string image;
        private string description;
        private double price;
        private double overallRating;

        public Product(int mproductID, int muserID, string mtitle, string mimage, string mdescription, double mprice, double moverallRating)
        {
            if (mproductID > -1)
            {
                productID = mproductID;
            }
            if (muserID > -1)
            {
                userID = muserID;
            }
            if (moverallRating >= 0.0 && moverallRating <= 5.0)
            {
                overallRating = moverallRating;
            }
            setTitle(mtitle);
            setImage(mimage);
            setDescription(mdescription);
            setPrice(mprice);
        }

        public int getProductID()
        {
            return productID;
        }

        public int getUserID()
        {
            return userID;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string mtitle)
        {
            if (!string.IsNullOrWhiteSpace(mtitle) && mtitle.Length <= 100)
            {
                title = mtitle;
            }
        }

        public string getImage()
        {
            return image;
        }

        public void setImage(string mimage)
        {
            if (!string.IsNullOrWhiteSpace(mimage) && mimage.Length <= 255)
            {
                image = mimage;
            }
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string mdescription)
        {
            if (!string.IsNullOrWhiteSpace(mdescription)
                && mdescription.Length <= 1000)
            {
                description = mdescription;
            }
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double mprice)
        {
            if (!double.IsNaN(mprice) && !double.IsInfinity(mprice)
                && mprice >= 0.0 && mprice <= 1000000.0)
            {
                price = mprice;
            }
        }

        public double getOverallRating()
        {
            return overallRating;
        }
    }

}
