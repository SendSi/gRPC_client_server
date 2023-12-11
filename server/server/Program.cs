using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<LoginerService>();
app.MapGrpcService<ChaterService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();




//using Microsoft.AspNetCore.Hosting.Server;

//class Program
//{
//    static void Main(string[] args)
//    {
//        server server = new server
//        {
//            Services = { Loginer.BindService(new SayHelloImpl()) },
//            Ports = { new ServerPort("localhost", 50051, ServerCredentials.Insecure) }
//        };
//        server.Start();
//        Console.WriteLine("Server Start On Locolhost:50051");
//        Console.WriteLine("Press any key to stop the server...");
//        Console.ReadKey();
//        server.ShutdownAsync().Wait();
//    }
//}


