using BooruSharp.Booru;
using Discord.Webhook;
using DiscordNSFWWebhook;
using Newtonsoft.Json;

var webhooks = JsonConvert.DeserializeObject<List<Webhooks>>(File.ReadAllText("webhooks.json"));

foreach (var webhook in webhooks)
{
    ABooru booru = webhook.Booru switch
    {
        "rule34" => new Rule34(),
        "safebooru" => new Safebooru(),
        _ => new Rule34()
    };
#pragma warning disable CS4014
    RandomBooruPicToWebhookTask(new(webhook.Url), booru, webhook.Tags.ToArray(), TimeSpan.FromSeconds(webhook.Interval), CancellationToken.None);
#pragma warning restore CS4014
}

while (true)
{
}

async Task RandomBooruPicToWebhookTask(DiscordWebhookClient webhook, ABooru booru, string[] tags, TimeSpan interval, CancellationToken cancellationToken)
{
    while (true)
    {
        var pic = await booru.GetRandomPostAsync(tags);
        Console.WriteLine(pic);
        await webhook.SendMessageAsync(pic.FileUrl.AbsoluteUri);
        await Task.Delay(interval, cancellationToken);
    }
}