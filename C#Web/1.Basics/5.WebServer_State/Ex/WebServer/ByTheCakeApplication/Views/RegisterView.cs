﻿namespace WebServer.ByTheCakeApplication.Views
{
    using Server.Contracts;

    public class RegisterView : IView
    {
        public string View()
        {
            return 
                "<body>" +
                "   <form method=\"POST\">" +
                "       Name</br>" +
                "       <input type=\"text\" name=\"name\" /></br>" +
                "       <input type=\"submit\" /></br>" + 
                "   </form>" + 
                "</body>";
        }
    }
}
