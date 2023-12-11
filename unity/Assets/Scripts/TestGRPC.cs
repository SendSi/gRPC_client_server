using Grpc.Net.Client;
using Grpc.Net.Extensions;
using server;
using UnityEngine;

public class TestGRPC : MonoBehaviour
{
   
    async void Start()
    {
        Debug.LogError("---开始---");
        var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions()
        {
            HttpHandler = new GRPCBestHttpHandler()
        });

        var client = new Greeter.GreeterClient(channel);
        var res = await client.SayHelloAsync(new HelloRequest()
        {
            Name = "造就helloworld"
        });
        Debug.LogError(res.Message);
        Debug.LogError("---结束---");
    }
    
}