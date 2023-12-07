using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Week_10_1.Persistence.Context;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddMemoryCache();


        var connectionString = builder.Configuration.GetSection("Yetgenpostgresql").Value;

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        builder.Services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
       
        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        var connecitonString = builder.Configuration.GetSection("yetgenpostgre").Value;

        builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseNpgsql(connectionString));
        //builder.Services.AddSharedServices();
   

        app.UseCors("AllowAll");


        var requestLocalizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

        if (requestLocalizationOptions is not null) app.UseRequestLocalization(requestLocalizationOptions.Value);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}