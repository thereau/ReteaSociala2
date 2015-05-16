using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ReteaSocialaMDS.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            var userID = Context.User.Identity.GetUserId();

            Groups.Add(Context.ConnectionId, userID);

            return base.OnConnected();

        }
        public void Send(string friendUserId, string message)
        {
            string currentUserId = Context.ConnectionId;
            string name = Context.User.Identity.Name;
           
            var userID = Context.User.Identity.GetUserId();
            //Clients.User(friendUserId).sendMessage(userID,message);
            Clients.Group(friendUserId).sendMessage(userID, message);
           

        }
    }
}