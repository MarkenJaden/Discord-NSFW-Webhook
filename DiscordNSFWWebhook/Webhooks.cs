namespace DiscordNSFWWebhook
{
    public class Webhooks
    {
        public string Url { get; set; }
        public string Booru { get; set; }
        public string[] Tags { get; set; }
        public int Interval { get; set; }

        public Webhooks(string url, string booru, string[] tags, int interval)
        {
            Url = url;
            Booru = booru;
            Tags = tags;
            Interval = interval;
        }
    }
}
