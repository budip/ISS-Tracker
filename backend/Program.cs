var builder = WebApplication.CreateBuilder(args);

// Add CORS to allow all origins (or restrict it to localhost:3000 if required)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Enable Swagger for ALL environments (including production)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = "swagger"; // This means Swagger will be available at /swagger
});

// Enable CORS globally
app.UseCors("AllowAll");

// If you prefer, you can enable HTTPS redirection by uncommenting the following line
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();