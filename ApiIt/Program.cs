using lib;
using lib.requests;
using System.Runtime.CompilerServices;
namespace ApiIt
{
    public class Program { 
        public static async Task Main(string[] args)
        {
            var _client = new HttpClient();

            var res = Console.ReadLine();
            var req = new JsonRequest(_client);
            var msg = await req.GetData<string>("https://grpersonal.site");
            if (msg.IsSuccess)
            {
                Console.WriteLine(msg.Data);
            }
            else
            {
                Console.WriteLine(msg.ErrorMessage);
            }
        }
    }
}
