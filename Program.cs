using Discord;
using Discord.WebSocket;
using Discord_Bot.config;

namespace Discord_Bot
{
    internal class Program
    {
        private readonly DiscordSocketClient client;
        public string token;



        public Program()
        {
            this.client = new DiscordSocketClient(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            });

            this.client.MessageReceived += MessageHandler;
        }

        public async Task StartBotAsync()
        {

            var jsonReader = new JSONReader();
            await jsonReader.ReadJson();

            token = jsonReader.token;

            this.client.Log += LogFuncAsync;
            await this.client.LoginAsync(TokenType.Bot, token);
            await this.client.StartAsync();
            await Task.Delay(-1);
            async Task LogFuncAsync(LogMessage message) =>
                Console.WriteLine(message);


        }

        private async Task MessageHandler(SocketMessage message)
        {
            if (message.Author.IsBot) return;

            Discord_Bot.MessageHandler.MessageReceiver(message);


        }



        static async Task Main(string[] args)
        {



            var myBot = new Program();
            await myBot.StartBotAsync();

        }

    }
}
