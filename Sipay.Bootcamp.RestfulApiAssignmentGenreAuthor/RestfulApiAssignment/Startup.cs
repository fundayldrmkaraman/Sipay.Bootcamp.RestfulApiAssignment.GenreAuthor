
using Microsoft.OpenApi.Models;
using RestfulApiAssignment;
using RestfulApiAssignment.Books;
using RestfulApiAssignment.Users;

namespace Assignment1;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public const string FakeUsername = "janedoe";
    public const string FakePassword = "12345";

    // This method gets called by the runtime. Use this method to add services to the container.
    [Obsolete]
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<BookService, BookService>();
        services.AddSingleton<IUserService, UserService>();

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment2 Collection", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment2 v1"));
        }

        app.UseMiddleware<GlobalLoggingMiddleware>();

        app.UseRouting();

        app.UseAuthorization();

        app.Use(async (context, next) =>
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var authHeader = context.Request.Headers["Authorization"];
            var token = authHeader.ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token) && ValidateToken(token))
            {
                await next();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    public bool ValidateToken(string token)
    {
        return token == "fakeToken";
    }
}
