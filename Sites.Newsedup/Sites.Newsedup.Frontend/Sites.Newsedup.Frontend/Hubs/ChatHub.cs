using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Sites.Newsedup.Frontend.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }


        public void GetNews()
        {
            // Call the addNewMessageToPage method to update clients.
            return;
            for (var i = 0; i < 100; i++)
            {
                Clients.All.addNewMessageToPage("dsfdsffds" + i, "message" + i);
                Thread.Sleep(1000);
            }
        }
    }
}