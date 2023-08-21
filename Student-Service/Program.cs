namespace Student_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddScoped<StudentRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            //builder.Services.AddScoped<IStudentRepo, StudentArrayRepo>();    
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseSwagger();
            //app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                // c.RoutePrefix = string.Empty;
            });



            app.MapControllers();

            app.Run();
        }
    }
}