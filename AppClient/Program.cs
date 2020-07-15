using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace AppClient
{
    class Program
    {
        private static HubConnection _connection;
        static async Task Main(string[] args)
        {
            await StartConnectionAsync();


            Console.WriteLine("Listenning messages...");
            _connection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine($"said: {message}");
            });


            await _connection.SendAsync("ReceiveMessage", "Hello from Console!");
            //await _connection.SendCoreAsync("SendHello", new[] { "Hello from Console!" });

            Console.ReadLine();
            await DisposeAsync();
        }

        public static async Task StartConnectionAsync()
        {
            _connection = new HubConnectionBuilder()
                 .WithUrl("http://localhost:5000/signalHub")
                 .Build();


            await _connection.StartAsync();
        }

        public static async Task DisposeAsync()
        {
            await _connection.DisposeAsync();
        }
    }
}
