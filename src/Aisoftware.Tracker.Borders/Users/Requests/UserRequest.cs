namespace Aisoftware.Tracker.Borders.Users.Requests
{
    /// <summary>
    /// name: string<br/>
    /// email: string<br/>
        /// </summary>
    
    public class UserRequest
    {
        private string name;
        private string email;
    
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
    }
}