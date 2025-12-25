using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VoteApi.Data;

var builder = WebApplication.CreateBuilder(args);

//cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


builder.Services.AddDbContext<VotingDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Controllers + API Explorer
builder.Services.AddControllers();          
builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod().AllowCredentials()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));


//migrate pending migrations
using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<VotingDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.Run();


