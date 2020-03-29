using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatView.Models.Connection
{
    public class MyHub: Hub
    {
        public async Task JoinMyHub(string userguid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userguid);
        }
        public async Task LeaveMyHub(string userguid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userguid);
        }
        public async Task UpdateNotification(string globalguid,int count)
        {
                await Clients.Group(globalguid).SendAsync("IncreaseNotification", count);
        }

    }
}
