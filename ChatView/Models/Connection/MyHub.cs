using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatView.Models.Connection
{
    public class MyHub: Hub
    {
        //Sadaqat Portion
        public async Task JoinMyHub(string userguid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userguid);
            await Clients.Others.SendAsync("UserOnline",userguid);
        }
        public async Task LeaveMyHub(string userguid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userguid);
            await Clients.Others.SendAsync("UserOffline", userguid);
        }
        public async Task UpdateNotification(string globalguid,int count)
        {
                await Clients.Group(globalguid).SendAsync("IncreaseNotification", count);
        }


        //Nasir Portion


    }
}
