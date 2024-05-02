namespace Mailtrap
{
    public class MailtrapMessage
	{
		public MailtrapAddress? From { get; set; }
        public List<MailtrapAddress>? To { get; set; }
		public string? Subject { get; set; }
        public string? Text { get; set; }
        public string? Html { get; set; }
        public string Category { get; set; } = "Integration Test";
        public List<MailtrapAttachment> Attachments { get; set; } = new List<MailtrapAttachment>();
    }
}

