using System.Threading.Tasks;

namespace GeoLocUtility;

public class Program
{
    public static async Task Main(string[] args)
    {
        var application = new Application();
        await application.Run(args);
    }
}
