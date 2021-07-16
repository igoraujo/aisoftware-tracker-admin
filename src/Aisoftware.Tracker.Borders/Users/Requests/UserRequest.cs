namespace Aisoftware.Tracker.Borders.Users.Requests
{
    /// <summary>
    /// name: string<br/>
    /// email: string<br/>
        /// </summary>
    
    public class UserRequest
    {
        private string email;
    
        private string password;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}