namespace BattleCards
{
    using SUS.MvcFramework;
    using System.Threading.Tasks;

    public class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: <StartUp>
            await Host.CreateHostAsync(new StartUp(), 80);
        }
    }
}
