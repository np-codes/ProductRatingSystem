using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Associations: DBConnectorControl reads and writes the SQLite database and
    //               builds UserAccount, Product, ProductList, ProductRating and
    //               ReviewList objects from the rows.
    public class DBConnectorControl
    {
        private string connectionString;

        private const string timestampFormat = "yyyy-MM-dd'T'HH:mm:ss";

        public DBConnectorControl()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = Path.Combine(AppContext.BaseDirectory, "ProductRatingSystem.db");
            builder.ForeignKeys = true;
            builder.Pooling = false;
            connectionString = builder.ToString();
        }

        public void initializeDB()
        {
            using (SqliteConnection connection = openConnection())
            using (SqliteTransaction transaction = connection.BeginTransaction())
            {
                runNonQuery(connection, transaction,
                    "CREATE TABLE IF NOT EXISTS USERACCOUNT (" +
                    "  userID INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "  username TEXT NOT NULL UNIQUE," +
                    "  passwordHash TEXT NOT NULL," +
                    "  role TEXT NOT NULL CHECK (role IN ('Customer', 'Seller')))");

                runNonQuery(connection, transaction,
                    "CREATE TABLE IF NOT EXISTS PRODUCT (" +
                    "  productID INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "  title TEXT NOT NULL," +
                    "  image TEXT," +
                    "  description TEXT," +
                    "  price REAL NOT NULL DEFAULT 0," +
                    "  overallRating REAL NOT NULL DEFAULT 0," +
                    "  sellerID INTEGER NOT NULL," +
                    "  FOREIGN KEY (sellerID) REFERENCES USERACCOUNT (userID))");

                runNonQuery(connection, transaction,
                    "CREATE TABLE IF NOT EXISTS PRODUCTRATING (" +
                    "  ratingID INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "  rating INTEGER NOT NULL," +
                    "  review TEXT," +
                    "  timestamp TEXT NOT NULL," +
                    "  buyerID INTEGER NOT NULL," +
                    "  productID INTEGER NOT NULL," +
                    "  FOREIGN KEY (buyerID) REFERENCES USERACCOUNT (userID)," +
                    "  FOREIGN KEY (productID) REFERENCES PRODUCT (productID))");

                runNonQuery(connection, transaction,
                    "CREATE TABLE IF NOT EXISTS PURCHASE (" +
                    "  buyerID INTEGER NOT NULL," +
                    "  productID INTEGER NOT NULL," +
                    "  rated INTEGER NOT NULL DEFAULT 0," +
                    "  PRIMARY KEY (buyerID, productID)," +
                    "  FOREIGN KEY (buyerID) REFERENCES USERACCOUNT (userID)," +
                    "  FOREIGN KEY (productID) REFERENCES PRODUCT (productID))");

                runNonQuery(connection, transaction,
                    "CREATE TABLE IF NOT EXISTS SESSIONLOG (" +
                    "  sessionID INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "  username TEXT," +
                    "  eventType TEXT NOT NULL," +
                    "  timestamp TEXT NOT NULL," +
                    "  userID INTEGER," +
                    "  FOREIGN KEY (userID) REFERENCES USERACCOUNT (userID))");

                long accountCount = 0;
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "SELECT COUNT(*) FROM USERACCOUNT";
                    accountCount = Convert.ToInt64(command.ExecuteScalar());
                }
                if (accountCount == 0)
                {
                    insertSampleData(connection, transaction);
                }

                transaction.Commit();
            }
        }

        public UserAccount getAccount(string musername, string mpasswordHash)
        {
            if (string.IsNullOrEmpty(musername) || string.IsNullOrEmpty(mpasswordHash))
            {
                return null;
            }

            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT userID, username, passwordHash, role FROM USERACCOUNT " +
                    "WHERE username = @username AND passwordHash = @passwordHash";
                command.Parameters.AddWithValue("@username", musername);
                command.Parameters.AddWithValue("@passwordHash", mpasswordHash);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserAccount(reader.GetInt32(0), readString(reader, 1),
                            readString(reader, 2), readString(reader, 3));
                    }
                }
            }
            return null;
        }

        // Records an event for a known user (LOGIN, LOGOUT).
        public void logSession(int muserID, string meventType, DateTime mtimestamp)
        {
            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO SESSIONLOG (username, eventType, timestamp, userID) " +
                    "SELECT username, @eventType, @timestamp, userID FROM USERACCOUNT " +
                    "WHERE userID = @userID";
                command.Parameters.AddWithValue("@eventType", toDb(meventType));
                command.Parameters.AddWithValue("@timestamp", formatTimestamp(mtimestamp));
                command.Parameters.AddWithValue("@userID", muserID);
                command.ExecuteNonQuery();
            }
        }

        // Records an event for an unknown user (FAILED_LOGIN): userID stays NULL.
        public void logSession(string musername, string meventType, DateTime mtimestamp)
        {
            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO SESSIONLOG (username, eventType, timestamp, userID) " +
                    "VALUES (@username, @eventType, @timestamp, NULL)";
                command.Parameters.AddWithValue("@username", toDb(musername));
                command.Parameters.AddWithValue("@eventType", toDb(meventType));
                command.Parameters.AddWithValue("@timestamp", formatTimestamp(mtimestamp));
                command.ExecuteNonQuery();
            }
        }

        public ProductList getProducts()
        {
            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT productID, sellerID, title, image, description, price, overallRating " +
                    "FROM PRODUCT ORDER BY productID";
                return readProducts(command);
            }
        }

        // Seller: the products this seller listed.
        // Customer: the products this customer has not rated yet.
        public ProductList getProducts(int muserID)
        {
            using (SqliteConnection connection = openConnection())
            {
                string role = null;
                using (SqliteCommand roleCommand = connection.CreateCommand())
                {
                    roleCommand.CommandText = "SELECT role FROM USERACCOUNT WHERE userID = @userID";
                    roleCommand.Parameters.AddWithValue("@userID", muserID);
                    object result = roleCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        role = Convert.ToString(result);
                    }
                }

                using (SqliteCommand command = connection.CreateCommand())
                {
                    if (role == "Seller")
                    {
                        command.CommandText =
                            "SELECT productID, sellerID, title, image, description, price, overallRating " +
                            "FROM PRODUCT WHERE sellerID = @userID ORDER BY productID";
                    }
                    else if (role == "Customer")
                    {
                        command.CommandText =
                            "SELECT productID, sellerID, title, image, description, price, overallRating " +
                            "FROM PRODUCT WHERE productID NOT IN " +
                            "(SELECT productID FROM PURCHASE WHERE buyerID = @userID AND rated = 1) " +
                            "ORDER BY productID";
                    }
                    else
                    {
                        return new ProductList(new Product[0]);
                    }
                    command.Parameters.AddWithValue("@userID", muserID);
                    return readProducts(command);
                }
            }
        }

        public void saveProduct(int muserID, Product mproduct)
        {
            if (mproduct == null)
            {
                throw new ArgumentNullException(nameof(mproduct));
            }

            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO PRODUCT (title, image, description, price, overallRating, sellerID) " +
                    "VALUES (@title, @image, @description, @price, 0, @sellerID)";
                command.Parameters.AddWithValue("@title", toDb(mproduct.getTitle()));
                command.Parameters.AddWithValue("@image", toDb(mproduct.getImage()));
                command.Parameters.AddWithValue("@description", toDb(mproduct.getDescription()));
                command.Parameters.AddWithValue("@price", mproduct.getPrice());
                command.Parameters.AddWithValue("@sellerID", muserID);
                command.ExecuteNonQuery();
            }
        }

        // Returns a blank rating for the RatingForm. Nothing is saved here.
        public ProductRating getRatings(int mproductID)
        {
            return new ProductRating(0, mproductID, 0, 0, "", DateTime.Now);
        }

        // Saves the rating and marks the product as rated by this customer.
        // The average is not recalculated here (see updateRating).
        public void saveReview(int muserID, int mproductID, int mrating, string mreview, DateTime mtimestamp)
        {
            using (SqliteConnection connection = openConnection())
            using (SqliteTransaction transaction = connection.BeginTransaction())
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText =
                        "INSERT INTO PRODUCTRATING (rating, review, timestamp, buyerID, productID) " +
                        "VALUES (@rating, @review, @timestamp, @buyerID, @productID)";
                    command.Parameters.AddWithValue("@rating", mrating);
                    command.Parameters.AddWithValue("@review", toDb(mreview));
                    command.Parameters.AddWithValue("@timestamp", formatTimestamp(mtimestamp));
                    command.Parameters.AddWithValue("@buyerID", muserID);
                    command.Parameters.AddWithValue("@productID", mproductID);
                    command.ExecuteNonQuery();
                }

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText =
                        "INSERT INTO PURCHASE (buyerID, productID, rated) " +
                        "VALUES (@buyerID, @productID, 1) " +
                        "ON CONFLICT (buyerID, productID) DO UPDATE SET rated = 1";
                    command.Parameters.AddWithValue("@buyerID", muserID);
                    command.Parameters.AddWithValue("@productID", mproductID);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
        }

        public ReviewList getReviews(int mproductID)
        {
            List<ProductRating> ratings = new List<ProductRating>();

            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT ratingID, productID, buyerID, rating, review, timestamp " +
                    "FROM PRODUCTRATING WHERE productID = @productID " +
                    "ORDER BY timestamp DESC, ratingID DESC";
                command.Parameters.AddWithValue("@productID", mproductID);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ratings.Add(new ProductRating(reader.GetInt32(0), reader.GetInt32(1),
                            reader.GetInt32(2), reader.GetInt32(3), readString(reader, 4),
                            parseTimestamp(readString(reader, 5))));
                    }
                }
            }
            return new ReviewList(ratings.ToArray());
        }

        // The average itself is calculated by RateProductControl.
        public void updateRating(int mproductID, double maverage)
        {
            using (SqliteConnection connection = openConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE PRODUCT SET overallRating = @average WHERE productID = @productID";
                command.Parameters.AddWithValue("@average", maverage);
                command.Parameters.AddWithValue("@productID", mproductID);
                command.ExecuteNonQuery();
            }
        }

        // ---- private helpers ----

        private SqliteConnection openConnection()
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }

        private void runNonQuery(SqliteConnection connection, SqliteTransaction transaction, string sql)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }

        private ProductList readProducts(SqliteCommand command)
        {
            List<Product> products = new List<Product>();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product(reader.GetInt32(0), reader.GetInt32(1),
                        readString(reader, 2), readString(reader, 3), readString(reader, 4),
                        reader.IsDBNull(5) ? 0.0 : reader.GetDouble(5),
                        reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6)));
                }
            }
            return new ProductList(products.ToArray());
        }

        private void insertSampleData(SqliteConnection connection, SqliteTransaction transaction)
        {
            insertAccount(connection, transaction, "customer1", "pass123", "Customer");
            insertAccount(connection, transaction, "seller1", "pass123", "Seller");
            insertAccount(connection, transaction, "customer2", "pass123", "Customer");
            insertAccount(connection, transaction, "seller2", "pass123", "Seller");
            insertAccount(connection, transaction, "customer3", "pass123", "Customer");
            insertAccount(connection, transaction, "seller3", "pass123", "Seller");

            long sellerID = 0;
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "SELECT userID FROM USERACCOUNT WHERE username = 'seller1'";
                sellerID = Convert.ToInt64(command.ExecuteScalar());
            }

            insertSampleProduct(connection, transaction, sellerID, "Wireless Headphones",
                "images/headphones.png", "Over-ear Bluetooth headphones with noise cancelling.", 79.99);
            insertSampleProduct(connection, transaction, sellerID, "Mechanical Keyboard",
                "images/keyboard.png", "Compact mechanical keyboard with blue switches.", 59.50);
            insertSampleProduct(connection, transaction, sellerID, "USB-C Charger",
                "images/charger.png", "45W fast charger for phones and laptops.", 24.99);
        }

        private void insertAccount(SqliteConnection connection, SqliteTransaction transaction,
            string username, string password, string role)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText =
                    "INSERT INTO USERACCOUNT (username, passwordHash, role) " +
                    "VALUES (@username, @passwordHash, @role)";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwordHash", hashPassword(password));
                command.Parameters.AddWithValue("@role", role);
                command.ExecuteNonQuery();
            }
        }

        private void insertSampleProduct(SqliteConnection connection, SqliteTransaction transaction,
            long sellerID, string title, string image, string description, double price)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText =
                    "INSERT INTO PRODUCT (title, image, description, price, overallRating, sellerID) " +
                    "VALUES (@title, @image, @description, @price, 0, @sellerID)";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@image", image);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@sellerID", sellerID);
                command.ExecuteNonQuery();
            }
        }

        // SHA-256 of the UTF-8 password as an uppercase hex string.
        // LoginControl must hash passwords the same way.
        private string hashPassword(string mpassword)
        {
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(mpassword)));
        }

        private string readString(SqliteDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? "" : reader.GetString(index);
        }

        private object toDb(string value)
        {
            return value == null ? DBNull.Value : value;
        }

        private string formatTimestamp(DateTime mtimestamp)
        {
            return mtimestamp.ToString(timestampFormat, CultureInfo.InvariantCulture);
        }

        private DateTime parseTimestamp(string text)
        {
            DateTime result;
            if (DateTime.TryParseExact(text, timestampFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result))
            {
                return result;
            }
            return DateTime.Now;
        }
    }
}
