namespace ProductRatingSystem.Control
{
    // Shared base for application controllers that need database access.
    public abstract class Controller
    {
        protected readonly DBConnectorControl db;

        protected Controller()
        {
            db = new DBConnectorControl();
        }
    }
}
