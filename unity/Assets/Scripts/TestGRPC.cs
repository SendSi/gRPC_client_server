using Grpc.Net.Client;
using Grpc.Net.Extensions;
using server;
using UnityEngine;

public class TestGRPC : MonoBehaviour
{

    async void HelloWorld()
    {
        Debug.LogError("---开始---");
        var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions()
        {
            HttpHandler = new GRPCBestHttpHandler()
        });

        var client = new Greeter.GreeterClient(channel);
        var res = await client.SayHelloAsync(new HelloRequest()
        {
            Name = "开始例子:helloWorld"
        });
        Debug.LogError(res.Message);
        Debug.LogError("---结束---");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("hello world"))
        {
            HelloWorld();
        }

        if (GUILayout.Button("hello mySql yes"))
        {
            HelloMySql("1234");
        }
        if (GUILayout.Button("hello mySql no"))
        {
            HelloMySql("z1001000");
        }
    }

    async void HelloMySql(string pwd)
    {
        Debug.LogError("---开始---");
        var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions()
        {
            HttpHandler = new GRPCBestHttpHandler()
        });

        var client = new Roleer.RoleerClient(channel);
        var res = await client.RoleLoginAsync(new ()
        {
            Account="z1001",
            Pwd=pwd
        });
        Debug.LogError("账号登录="+(res.State==1?"成功":"失败"));
        Debug.LogError("---结束---");
    }

}