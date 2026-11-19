using ProductRatingSystem.Boundary;

namespace ProductRatingSystem
{
    // Entry point of the application.
    public static class RatingSystem
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // The message loop is run with an ApplicationContext that has no main form,
            // so closing one window does not end the program (Startup -> Login -> menus
            // -> Login ...). The program ends when no visible form is left.
            ApplicationContext context = new ApplicationContext();
            EventHandler exitWhenNoVisibleForm = (sender, e) =>
            {
                if (!hasVisibleForm())
                {
                    context.ExitThread();
                }
            };
            Application.Idle += exitWhenNoVisibleForm;

            new StartupForm().display();
            Application.Run(context);

            Application.Idle -= exitWhenNoVisibleForm;
        }

        private static bool hasVisibleForm()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Visible)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
