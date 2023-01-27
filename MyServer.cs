using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets;
using Microsoft.Extensions.Options;

public class MyServer{
    public static async Task Start(){
        KestrelServerOptions kestrelServerOptions=new KestrelServerOptions(){
        
        };
        kestrelServerOptions.Listen(System.Net.IPAddress.Loopback,5001);

        SocketTransportFactory socketTransportFactory=new SocketTransportFactory(
            Options.Create(new SocketTransportOptions()),
            new LoggerFactory()
        );

        KestrelServer server=new KestrelServer(
            Options.Create(kestrelServerOptions),socketTransportFactory,new LoggerFactory());

        Console.WriteLine("Started Server ...");

        await server.StartAsync(new App(),CancellationToken.None);

    }
}