﻿using Newtonsoft.Json;

namespace Discord_Bot.config
{
    internal class JSONReader
    {
        public string? token { get; set; }

        public async Task ReadJson()
        {
            using (StreamReader sr = new StreamReader("config.json"))
            {
                string json = await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

                this.token = data.token;
            }
        }
    }

    internal sealed class JSONStructure
    {
        public string? token { get; set; }

    }
}
