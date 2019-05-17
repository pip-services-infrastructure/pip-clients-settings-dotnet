using PipServices.Settings.Client.Version1;
using PipServices3.Commons.Config;
using System;

namespace run
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
                var client = new SettingsHttpClientV1();
                client.Configure(config);              
                client.OpenAsync(correlationId);
                var parameters = client.SetSectionAsync(null, "test.1", ConfigParams.FromTuples(
                        "key1", "value11",
                        "key2", "value12"
                    ));
                var page = client.GetSectionsAsync(null, null, null);
                Console.WriteLine("Get sections: ");

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
