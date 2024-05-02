using System.Text;

namespace Mailtrap.Tests;

public class MailtrapSenderTest
{

    readonly MailtrapSender sender = new MailtrapSender();

    private MailtrapMessage CreateMessage()
    {
        return new MailtrapMessage()
        {
            From = new MailtrapAddress() { Email = "mailtrap@demomailtrap.com", Name = "Test" },
            To = new List<MailtrapAddress>() { { new MailtrapAddress() { Email = "polubin@gmail.com", Name = "Test" } } },
            Subject = "Test",
            Category = "Test"
        };
    }

    [Fact]
    public async Task SendText()
    {
        var message = CreateMessage();
        message.Text = "TEST";

        var response = await sender.SendAsync(message);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    public async Task SendHtml()
    {
        var message = CreateMessage();
        message.Html = "<p>Hello, world!</p>";

        var response = await sender.SendAsync(message);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    public async Task SendAttachment()
    {
        var message = CreateMessage();
        message.Html = "<p>Hello, world!</p>";

        var attachment = new MailtrapAttachment()
        {
            FileName = "test.html",
            Type = "type/html",
            Content = Convert.ToBase64String(Encoding.UTF8.GetBytes(message.Html))
        };

        message.Attachments.Add(attachment);

        var response = await sender.SendAsync(message);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
