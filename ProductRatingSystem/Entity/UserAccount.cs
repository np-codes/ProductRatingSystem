using System;

namespace ProductRatingSystem.Entity
{
    // Subsystem: Entity
    // Associations: a UserAccount (seller) lists many Product objects;
    //               a UserAccount (buyer) submits many ProductRating
    //               objects.
    public class UserAccount
    {
        private int userID;
        private string username;
        private string passwordHash;
        private string role;

        public UserAccount(int muserID, string musername, string mpasswordHash, string mrole)
        {
            if (muserID > -1)
            {
                userID = muserID;
            }
            if (!string.IsNullOrEmpty(mpasswordHash)
                && mpasswordHash.Length <= 256)
            {
                passwordHash = mpasswordHash;
            }
            setUsername(musername);
            setRole(mrole);
        }

        public int getUserID()
        {
            return userID;
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string musername)
        {
            if (!string.IsNullOrWhiteSpace(musername)
                && musername.Length <= 50)
            {
                username = musername;
            }
        }

        public string getRole()
        {
            return role;
        }

        public void setRole(string mrole)
        {
            if (mrole == "Customer" || mrole == "Seller")
            {
                role = mrole;
            }
        }
    }

}
