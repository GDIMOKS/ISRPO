using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Realization;
using Services.Song;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SongsDbContext>(x => x.UseNpgsql("Postgres"));

builder.Services.AddScoped<ISongService, SongService>();


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