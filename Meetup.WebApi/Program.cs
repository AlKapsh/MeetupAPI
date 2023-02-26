using Meetup.BLL.Contracts;
using Meetup.BLL.Services;
using Meetup.DAL.Contracts;
using Meetup.DAL.EF;
using Meetup.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<repContext>(opts => 
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => 
        b.MigrationsAssembly("MeetupAPI")));

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IMeetService, MeetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints => { 
    endpoints.MapControllers();
});


app.Run();
