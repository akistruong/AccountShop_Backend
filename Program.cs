using AccountShop.Models;
using static Google.Protobuf.Compiler.CodeGeneratorResponse.Types;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context,next) =>
{
    try
    {
        await next(context);
    }
    catch(Exception ex) { 
    Console.WriteLine(ex);
        context.Response.StatusCode = 500;  
    }
}); 
app.UseHttpsRedirection();
app.UseRouting();   
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllers(); 
});
//app.MapControllers();

app.Run();
