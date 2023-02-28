using Meetup.BLL.Contracts;
using Meetup.BLL.Services;
using Meetup.DAL.Contracts;
using Meetup.DAL.EF;
using Meetup.DAL.Models;
using Meetup.DAL.Repository;
using Meetup.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.JWTConfigure(builder.Configuration);

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();


var str = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<repContext>(opts => 
    opts.UseSqlServer(str, b => 
        b.MigrationsAssembly("Meetup.WebApi")));

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IMeetService, MeetService>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<UserManager<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { 
    endpoints.MapControllers();
});


app.Run();
