using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot
{
    internal class Commands
    {

        public static void HelpMessage(SocketMessage message)
        {
            string helpMessage = "Dearest " + message.Author.Username +
                " These are my commands:\n\n!help - get the list of commands" +
                "\n!cat - get a random image of a cat" +
                "\n!dog - get a random image of a dog"
                ;


            SendMessage(helpMessage, message);
        }

        public static void SendCat(SocketMessage message)
        {
            var response = GetImageLink.GetImage("https://api.thecatapi.com/v1/images/search");
            SendMessage($"Here is your {"cat"} {message.Author.Mention}", message);
            SendMessage(response, message);
        }

        public static void SendDog(SocketMessage message)
        {
            var response = GetImageLink.GetImage("https://api.thedogapi.com/v1/images/search");
            SendMessage($"Here is your {"dog"} {message.Author.Mention}", message);
            SendMessage(response, message);
        }


        public static void SendMessage(string response, SocketMessage message)
        {
            message.Channel.SendMessageAsync(response);



        }
    }
}
