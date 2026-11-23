using System.Windows.Forms;

namespace ProductRatingSystem.Boundary
{
    public abstract class ApplicationForm : Form
    {
        protected ApplicationForm()
        {
            Font = UiTheme.BodyFont;
            BackColor = UiTheme.WindowBackground;
            ForeColor = UiTheme.Text;
            AutoScaleMode = AutoScaleMode.Dpi;
        }
    }
}
