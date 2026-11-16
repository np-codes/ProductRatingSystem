using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRatingSystem.Entity
{
    // Subsystem: Entity
    // Associations: ProductRating -> Product (1) through productID;
    //               ProductRating -> UserAccount (buyer, 1) through userID;
    //               a ReviewList contains many ProductRating objects.
    public class ProductRating
    {
        private int ratingID;
        private int productID;
        private int userID;
        private int rating;
        private string review;
        private DateTime timestamp;

        public ProductRating(int mratingID, int mproductID, int muserID, int mrating, string mreview, DateTime mtimestamp)
        {
            if (mratingID > -1)
            {
                ratingID = mratingID;
            }
            if (mproductID > -1)
            {
                productID = mproductID;
            }
            if (muserID > -1)
            {
                userID = muserID;
            }
            if (mrating >= 1 && mrating <= 5)
            {
                rating = mrating;
            }
            if (!string.IsNullOrWhiteSpace(mreview)
                && mreview.Length <= 1000)
            {
                review = mreview;
            }
            if (mtimestamp <= DateTime.Now)
            {
                timestamp = mtimestamp;
            }
        }

        public int getRatingID()
        {
            return ratingID;
        }

        public int getProductID()
        {
            return productID;
        }

        public int getUserID()
        {
            return userID;
        }

        public int getRating()
        {
            return rating;
        }

        public string getReview()
        {
            return review;
        }

        public DateTime getTimestamp()
        {
            return timestamp;
        }
    }

}
