using ImageClassification.Adapter;
using ImageClassification.Core;
using ImageClassification.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registrations
builder.Services.AddSingleton<IImageClassificationService, ImageClassificationService>();
builder.Services.AddSingleton<IImageClassificationComponent, ImageClassificationComponent>();
builder.Services.AddSingleton<IImageClassificationAdapter, ImageClassificationAdapter>();

var app = builder.Build();

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