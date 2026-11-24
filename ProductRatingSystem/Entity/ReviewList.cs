using System;

namespace ProductRatingSystem.Entity
{
    // Subsystem: Entity
    // Associations: ReviewList contains many ProductRating objects.
    public class ReviewList
    {
        public ProductRating[] reviews;

        public ReviewList(ProductRating[] mreviews)
        {
            if (mreviews != null)
            {
                reviews = mreviews;
            }
            else
            {
                reviews = new ProductRating[0];
            }
        }

        public int getCount()
        {
            return reviews.Length;
        }

        public ProductRating getReview(int mindex)
        {
            if (mindex > -1 && mindex < reviews.Length)
            {
                return reviews[mindex];
            }
            return null;
        }
    }

}
