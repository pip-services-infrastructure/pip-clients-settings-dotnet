using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Settings.Client.Version1;
using System;

namespace PipServices.Quotes.Client.Run
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var correlationId = "123";
                var config = ConfigParams.FromTuples(
                    "connection.type", "http",
                    "connection.host", "localhost",
                    "connection.port", 8080
                );
                var filterParams = FilterParams.FromTuples(
                    "status", "completed",
                    "search", "goal");

                var client = new SettingsHttpClientV1();
                client.Configure(config);
                client.OpenAsync(correlationId);

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                client.CloseAsync(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }
}
