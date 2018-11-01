using AutoFixture.Xunit2;
using Previsul.Components.Logging.Domain.Model;
using Previsul.Components.Logging.Domain.Services;
using Xunit;

namespace Previsul.Components.Tests
{
    public class SlackClientTests
    {
        [Theory, AutoData]
        public void SendWeebHookToChanel_ShouldReturnSuccessful()
        {
            var payload = new MessagePayload
            {
                Application = "Integration Tests",
                Channel = "#notifications",
                Attachments = new[]
                {
                    new Attachment
                    {
                        Color = "#007bff",
                        Text = "Integration Tests",
                        Title = "Integration Test"
                    }
                }
            };
            SlackClient.SendMessage(payload);
        }
    }
}