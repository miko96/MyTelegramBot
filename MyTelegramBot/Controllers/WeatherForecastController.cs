using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MyTelegramBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : ControllerBase
    {
        private readonly ITelegramBotClient _client;

        public WebhookController(ITelegramBotClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task PostAsync()
        {

            await Task.CompletedTask;
            //await _client.SendTextMessageAsync(new ChatId(update.Message.Chat.Id), "Привет");
        }

        [HttpGet]
        public Task<WebhookInfo> GetHook()
        {
            return _client.GetWebhookInfoAsync();
        }

        [HttpGet("set")]
        public Task<bool> SetWebhook()
        {
            return _client.MakeRequestAsync(
                new SetWebhookRequest("https://mytelegrambot2.azurewebsites.net/webhook/post", null)
                {
                    AllowedUpdates = new[] { UpdateType.Message }
                });
        }
    }
}
