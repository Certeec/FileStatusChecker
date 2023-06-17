using FileStatusCheckerApplication.FileChecker;
using FileStatusCheckerApplication.TempFileOperators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileDirectionRepository, FileDirectionRepository>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IHistoricalFileHandler, HistoricalFileHandler>();
builder.Services.AddTransient<IFileDirectionChecker, FileDirectionChecker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
