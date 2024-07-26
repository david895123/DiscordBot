using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot
{
    internal class MessageHandler
    {
        public static void MessageReceiver(SocketMessage message)
        {


            switch (message.Content)
            {
                case "!help":
                    Commands.HelpMessage(message);
                    break;
                case "!cat":
                    Commands.SendCat(message);
                    break;
                case "!dog":
                    Commands.SendDog(message);
                    break;

            }
        }





    }
}
