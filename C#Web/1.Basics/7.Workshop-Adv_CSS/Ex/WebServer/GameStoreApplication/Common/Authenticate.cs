using System;
using System.Collections.Generic;
using System.Text;

namespace HTTPServer.GameStoreApplication.Common
{
    public class Authenticate
    {
        public Authenticate(bool isAuthenticated, bool isAdmin)
        {
            this.IsAuthenticated = isAuthenticated;
            this.IsAdmin = isAdmin;
        }

        public bool IsAuthenticated { get; private set; }

        public bool IsAdmin { get; private set; }
    }
}
