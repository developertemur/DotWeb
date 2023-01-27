using System.Text.Json;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

public class App : IHttpApplication<HttpContext>
{
    public HttpContext HttpContext {get; set;}=null!;
    public HttpContext CreateContext(IFeatureCollection contextFeatures)
    {
        return new DefaultHttpContext(contextFeatures);
    }

    public async Task ProcessRequestAsync(HttpContext context)
    {
        try{
            var req=context.Request;
            
            await context.Response.WriteAsync(
                // "\nBody:"+JsonSerializer.Serialize(req.Body)+
                "\nContentType:"+JsonSerializer.Serialize(req.ContentType)+
                "\nHeaders:"+JsonSerializer.Serialize(req.Headers)+
                "\nPath:"+JsonSerializer.Serialize(req.Path)+
                "\nMethod:"+JsonSerializer.Serialize(req.Method)+
                "\nQuery:"+JsonSerializer.Serialize(req.Query)
                );
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }

    public void DisposeContext(HttpContext context, Exception? exception)
    {
    }
}