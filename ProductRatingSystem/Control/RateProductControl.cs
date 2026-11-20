using System;
using System.Windows.Forms;
using ProductRatingSystem.Boundary;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Use case: RateProduct (RAD Table 2.4.6, Figure 2.5.6)
    // Associations: RateProductControl creates and controls the RatingForm and
    //               uses DBConnectorControl to save the rating, read the
    //               ReviewList, store the new overall rating and reload the
    //               customer's ProductList.
    public class RateProductControl
    {
        private int userID;
        private int productID;

        // Extra helper fields (not in the class diagram).
        private DBConnectorControl db;
        private RatingForm ratingForm;
        private Action<ProductList> showProducts;
        private string errorMessage;

        // Longest review that is accepted (same limit as ProductRating).
        public const int maxReviewLength = 1000;

        // mshowProducts is called with the refreshed list of unreviewed
        // products after the rating has been saved. The CustomerMenu passes a
        // method that shows the Customer Page again, e.g.
        //     new RateProductControl(list => display(list))
        public RateProductControl(Action<ProductList> mshowProducts)
        {
            userID = 0;
            productID = 0;
            db = new DBConnectorControl();
            showProducts = mshowProducts;
            errorMessage = "";
        }

        // Called by CustomerMenu.rateProduct() with the logged-in customer and
        // the selected product. Opens the Rating Page, which cannot be
        // cancelled until a valid rating has been submitted (RAD 1.1).
        public void rateProduct(int muserID, int mproductID)
        {
            userID = muserID;
            productID = mproductID;

            ProductRating productRating = db.getRatings(productID);

            // The Rating Page shows the product's title, image, description and
            // price, so the product is looked up in the customer's list of
            // products that are still waiting for a rating.
            Product product = findProduct(db.getProducts(userID), productID);
            if (product == null)
            {
                MessageBox.Show("This product is no longer available for rating.",
                    "Rate Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ratingForm = new RatingForm(this, product);
            ratingForm.display(productRating);
        }

        // Called by RatingForm.submit() with the chosen stars and the review text.
        public void submit(int mrating, string mreview)
        {
            if (!validate(mrating, mreview))
            {
                ratingForm.displayError(errorMessage);
                return;
            }

            try
            {
                db.saveReview(userID, productID, mrating, mreview.Trim(), DateTime.Now);
            }
            catch (Exception ex)
            {
                ratingForm.displayError("The rating could not be saved: " + ex.Message);
                return;
            }

            try
            {
                ReviewList reviewList = db.getReviews(productID);
                double average = calculateAverage(reviewList);
                db.updateRating(productID, average);
            }
            catch (Exception ex)
            {
                // The rating itself is saved; only the average failed. The page is
                // still closed so the same rating is not submitted twice.
                MessageBox.Show("The rating was saved, but the overall rating could not be updated: " + ex.Message,
                    "Rate Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ratingForm.close();

            ProductList productList = db.getProducts(userID);
            if (showProducts != null)
            {
                showProducts(productList);
            }
        }

        // Checks the rating and the review. On failure errorMessage names the
        // field that caused it (RAD 2.2 Usability). All database access uses
        // parameters, so the text can never change the SQL (RAD 2.2 Security).
        private bool validate(int mrating, string mreview)
        {
            errorMessage = "";

            if (mrating < 1 || mrating > 5)
            {
                errorMessage = "Rating: please select from 1 to 5 stars.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(mreview))
            {
                errorMessage = "Review: please write a review.";
                return false;
            }

            string review = mreview.Trim();
            if (review.Length > maxReviewLength)
            {
                errorMessage = "Review: please use at most " + maxReviewLength + " characters (it has "
                    + review.Length + ").";
                return false;
            }

            foreach (char letter in review)
            {
                if (char.IsControl(letter) && letter != '\r' && letter != '\n' && letter != '\t')
                {
                    errorMessage = "Review: the text contains characters that are not allowed.";
                    return false;
                }
            }

            return true;
        }

        // Average of all valid star ratings in the list, rounded to 2 decimals.
        // Returns 0 when there are no ratings.
        private double calculateAverage(ReviewList mreviewList)
        {
            if (mreviewList == null)
            {
                return 0.0;
            }

            int total = 0;
            int count = 0;
            for (int i = 0; i < mreviewList.getCount(); i++)
            {
                ProductRating rating = mreviewList.getReview(i);
                if (rating != null && rating.getRating() >= 1 && rating.getRating() <= 5)
                {
                    total += rating.getRating();
                    count++;
                }
            }

            if (count == 0)
            {
                return 0.0;
            }
            return Math.Round((double)total / count, 2);
        }

        // Helper: finds a product by ID in a ProductList, or returns null.
        private Product findProduct(ProductList mproductList, int mproductID)
        {
            if (mproductList == null)
            {
                return null;
            }
            for (int i = 0; i < mproductList.getCount(); i++)
            {
                Product product = mproductList.getProduct(i);
                if (product != null && product.getProductID() == mproductID)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
