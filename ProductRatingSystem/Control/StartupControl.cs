using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Associations: StartupControl uses DBConnectorControl to prepare the
    //               database and (later) creates the LoginForm.
    public class StartupControl
    {
        private string configFile;
        private Dictionary<string, string> settings;

        public StartupControl()
        {
            configFile = Path.Combine(AppContext.BaseDirectory, "config.txt");
            settings = new Dictionary<string, string>();
        }

        // Called by StartupForm when the Startup button is clicked.
        // If initializeDB() fails the exception is not caught here: StartupForm
        // shows the message and stays open.
        // Does not call Application.Run: the message loop is already running
        // (see RatingSystem), so the next form is simply shown.
        public void initiate()
        {
            loadConfiguration();

            DBConnectorControl db = new DBConnectorControl();
            db.initializeDB();

            // TODO (Member 2): once LoginForm exists, replace the next two lines with
            //     LoginForm loginForm = new LoginForm();
            //     loginForm.display();
            // and add "using ProductRatingSystem.Boundary;" at the top of this file.
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        // Reads simple "key=value" lines from config.txt. A missing or
        // unreadable file is not an error: the defaults (no settings) are used.
        private void loadConfiguration()
        {
            settings.Clear();
            try
            {
                if (!File.Exists(configFile))
                {
                    return;
                }
                foreach (string line in File.ReadAllLines(configFile))
                {
                    string text = line.Trim();
                    if (text.Length == 0 || text.StartsWith("#"))
                    {
                        continue;
                    }
                    int equals = text.IndexOf('=');
                    if (equals > 0)
                    {
                        settings[text.Substring(0, equals).Trim()] = text.Substring(equals + 1).Trim();
                    }
                }
            }
            catch (Exception)
            {
                settings.Clear();
            }
        }
    }
}
