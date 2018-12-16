using FacebookClone.Handlers;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class MessengerController : Controller
    {
        [Authorize]
        public ActionResult ShowMessenger()
        {
            var userId = User.Identity.GetUserId();
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(userId);
            return View(new MessengerViewModel(user));
        }

        [Authorize]
        public ActionResult ShowChat(string id)
        {
            var receiver_id = User.Identity.GetUserId();
            return   View("ShowMessenger",new MessengerViewModel(receiver_id, id));
        }

        [Authorize]
        public ActionResult AcceptFriendRequest(string Id)
        {
            return View("ShowMessenger");
        }

        [Authorize]
        public ActionResult AcceptGroupRequest(AspNetUser sender,string actionId, int message_id)
        {   
            var group_id = int.Parse(actionId);
            var receiver_id = User.Identity.GetUserId();
            GroupHandler.addUserToGroup(sender.Id, group_id, message_id);
            return RedirectToAction("ShowChat", "Messenger", new { id = sender.Id});
        }

        [Authorize]
        [HttpPost]
        public ActionResult SendMessage(ConversationViewModel conversation)
        {
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var currentUserId = User.Identity.GetUserId();
            var message = new Message() { sender_id = currentUserId, receiver_id = conversation.sendToUserId, content = conversation.inputText, date = DateTime.Now, type = Convert.ToInt32(MessageTypes.normalMessage) };

            MessageHandler.sendMessage(message);

            return RedirectToAction("ShowChat", "Messenger", new { id = conversation.sendToUserId });
        }
        

    }
}