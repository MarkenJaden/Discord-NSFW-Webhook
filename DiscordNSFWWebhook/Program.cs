using BooruSharp.Booru;
using Discord.Webhook;

var lines = File.ReadAllLines("webhooks.txt");

var tasks = new List<(DiscordWebhookClient webhook, ABooru booru, string[] tags, TimeSpan interval)>
{
    (new(lines[0]), new Rule34(), new []{ "cat_ears" }, TimeSpan.FromSeconds(600)),
    (new(lines[1]), new Rule34(), Array.Empty<string>(), TimeSpan.FromSeconds(600)),
    (new(lines[2]), new Safebooru(), Array.Empty<string>(), TimeSpan.FromSeconds(600)),
};

foreach (var (webhook, booru, tags, interval) in tasks)
{
#pragma warning disable CS4014
    RandomBooruPicToWebhookTask(webhook, booru, tags, interval, CancellationToken.None);
#pragma warning restore CS4014
}

while (true) ;

    async Task RandomBooruPicToWebhookTask(DiscordWebhookClient webhook, ABooru booru, string[] tags, TimeSpan interval, CancellationToken cancellationToken)
{
    while (true)
    {
        var pic = await booru.GetRandomPostAsync(tags);
        await webhook.SendMessageAsync(pic.FileUrl.AbsoluteUri);
        await Task.Delay(interval, cancellationToken);
    }
}