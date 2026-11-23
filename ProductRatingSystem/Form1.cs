using ProductRatingSystem.Boundary;

namespace ProductRatingSystem
{
    // Compatibility entry point for code that still opens Form1.
    // The actual login UI is LoginForm in the Boundary subsystem.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += form1_Shown;
        }

        public void display()
        {
            Show();
        }

        public void close()
        {
            Close();
        }

        private void form1_Shown(object? sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.display();
            close();
        }
    }
}
