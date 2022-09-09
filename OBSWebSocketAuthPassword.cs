using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5
{
    public class OBSWebSocketAuthPassword : OBSWebSocketAuth
    {
        public string Password { get; set; }

        public OBSWebSocketAuthPassword(string password)
        {
            Password = password;
        }
    }
}
