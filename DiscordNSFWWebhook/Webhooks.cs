namespace DiscordNSFWWebhook
{
    public class Webhooks
    {
        public string url { get; set; }
        public string booru { get; set; }
        public string[] tags { get; set; }
        public int interval { get; set; }

        public Webhooks(string url, string booru, string[] tags, int interval)
        {
            this.url = url;
            this.booru = booru;
            this.tags = tags;
            this.interval = interval;
        }
    }
}
