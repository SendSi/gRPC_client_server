// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using server;

class Program
{
    static void Main(string[] args)
    {
        StartMethod();

        using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
        {
            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest()
            {
                Name = "客户端 sayHeloName"
            });
            var msg = reply.Message;
            Console.WriteLine(msg);

            var login = new Loginer.LoginerClient(channel);
            var reply2 = login.AccountEnter(new LoginRequest()
            {
                Name = "客户端 sayHeloName",
                Age="20"
            });
            var msg2 = reply2.State;
            Console.WriteLine(msg2);
            Console.WriteLine("发送群聊");
            var chat = new Chater.ChaterClient(channel);
            var chatRes = chat.BroadAll(new SendMSGRequest()
            {
                Name="小明",
                Content="明天下雨"
            });
            Console.WriteLine(chatRes.Name+"__"+chatRes.Content);
            Console.WriteLine("发送私聊");
            var pri = chat.SendToPerson(new SendPersonRequest()
            {
                SendName="小明",
                ReceiveName="小丽",
                Content="在干嘛"
            });
            Console.WriteLine("1成功,,其他失败,结果是="+(pri.State==1?"成功":"失败"));

        }



        Console.ReadKey();
    }


    static void StartMethod()
    {
        Console.WriteLine("哈哈 开始");
    }
}