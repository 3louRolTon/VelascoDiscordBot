using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using VelascoDiscordBot.Services;

namespace VelascoDiscordBot
{
    class VelascoBotClient
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _cmdService;
        private readonly LogService _logService;

        public VelascoBotClient()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 50,
                LogLevel = LogSeverity.Debug
            });

            _logService = new LogService();
        }

        public async Task InitializeAsync()
        {
            await _client.LoginAsync(TokenType.Bot, Token.Key);
            await _client.StartAsync();
            _client.Log += LogAsync;

            await Task.Delay(-1);
        }

        private async Task LogAsync(LogMessage logMessage)
        {
            await _logService.LogAsync(logMessage);
        }
    }
}
