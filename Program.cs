
public class Program{
    public static async Task Main(){
        await MyServer.Start();
        while(true){
            await Task.Delay(1000);
        }
    }
}
