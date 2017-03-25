using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System;

namespace MeetMe.Web.Hubs
{
    public class Chat : Hub
    {
        public void SendMessage(string message, string projectId)
        {
            var username = this.Context.User.Identity.GetUserName();
            try
            {
                int projectIdParsed = int.Parse(projectId);
                // var newMessage = this.messageService.Create(message, username, projectIdParsed);
                // Clients.Group(projectId).addMessage(newMessage);
            }
            catch (Exception ex)
            {
                Clients.Caller.parseError(ex.Message);
            }
        }
    }
}