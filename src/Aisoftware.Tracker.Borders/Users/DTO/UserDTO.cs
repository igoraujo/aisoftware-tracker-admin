using System;

namespace Aisoftware.Tracker.Borders.Users.DTO
{
    /// <summary>
    /// id: int<br/>
    /// name: string<br/>
    /// email: string<br/>
    /// phone: string<br/>
    /// readonly: bool<br/>
    /// administrator: bool<br/>
    /// map: string<br/>
    /// latitude: decimal<br/>
    /// longitude: decimal<br/>
    /// zoom: decimal<br/>
    /// password: string<br/>
    /// twelveHourFormat: bool<br/>
    /// coordinateFormat: string<br/>
    /// disabled: bool<br/>
    /// expirationTime: DateTime<br/>
    /// deviceLimit: int<br/>
    /// userLimit: int<br/>
    /// deviceReadonly: bool<br/>
    /// limitCommands: bool<br/>
    /// poiLayer: string<br/>
    /// token: string<br/>
    /// attributes: object
    /// </summary>
    public class UserDTO
    {
        private int id;
        private string name;
        private string email;
        private string phone;
        private bool _readonly;
        private bool administrator;
        private string map;
        private decimal latitude;
        private decimal longitude;
        private decimal zoom;
        private string password;
        private bool twelveHourFormat;
        private string coordinateFormat;
        private bool disabled;
        private DateTime expirationTime;
        private int deviceLimit;
        private int userLimit;
        private bool deviceReadonly;
        private bool limitCommands;
        private string poiLayer;
        private string token;
        private object attributes;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public bool Readonly { get => _readonly; set => _readonly = value; }
        public bool Administrator { get => administrator; set => administrator = value; }
        public string Map { get => map; set => map = value; }
        public decimal Latitude { get => latitude; set => latitude = value; }
        public decimal Longitude { get => longitude; set => longitude = value; }
        public decimal Zoom { get => zoom; set => zoom = value; }
        public string Password { get => password; set => password = value; }
        public bool TwelveHourFormat { get => twelveHourFormat; set => twelveHourFormat = value; }
        public string CoordinateFormat { get => coordinateFormat; set => coordinateFormat = value; }
        public bool Disabled { get => disabled; set => disabled = value; }
        public DateTime ExpirationTime { get => expirationTime; set => expirationTime = value; }
        public int DeviceLimit { get => deviceLimit; set => deviceLimit = value; }
        public int UserLimit { get => userLimit; set => userLimit = value; }
        public bool DeviceReadonly { get => deviceReadonly; set => deviceReadonly = value; }
        public bool LimitCommands { get => limitCommands; set => limitCommands = value; }
        public string PoiLayer { get => poiLayer; set => poiLayer = value; }
        public string Token { get => token; set => token = value; }
        public object Attributes { get => attributes; set => attributes = value; }
    }
}