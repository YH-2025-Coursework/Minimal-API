namespace Minimal_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Enable Swagger middleware (development only)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Secure connection
            app.UseHttpsRedirection();

            // Endpoints
            app.MapGet("/hello/{name}", (string name) =>
            {
                return Results.Ok($"Hello, {name}");
            });

            app.Run();
        }
    }
}
