using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
{
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});



var app = builder.Build();

app.UseCors("DevCorsPolicy");
/* Safe way
app.UseCors(policy =>
{
    //Server api , client api
    policy.WithOrigins("http://localhhost:5111", "http://localhhost:5112").AllowAnyMethod().WithHeaders(HeaderNames.ContentType);
});
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("test");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
