using System.Threading.Tasks;

namespace VelascoDiscordBot
{
    class Program
    {
        static async Task Main(string[] args)
            => await new VelascoBotClient().InitializeAsync();
    }
}