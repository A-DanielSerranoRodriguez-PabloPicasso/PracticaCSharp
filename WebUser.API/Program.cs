using Microsoft.EntityFrameworkCore;
using WebUser.BL.Contracts;
using WebUser.BL.Implementations;
using WebUser.Core.Profiles;
using WebUser.DAL;
using WebUser.DAL.Contracts;
using WebUser.DAL.Implementations;
//using WebUser.Core.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();

builder.Services.AddDbContext<IESContext>();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new AutoMapperProfile()));

// Enable CORS in API  
string[] ExposedHeaders = { "Authoritation" };
builder.Services.AddCors(o => {
    o.AddPolicy("AllowSetOrigins", options =>
    {
        options.WithOrigins("https://127.0.0.1:7179");
        options.WithOrigins("https://127.0.0.1:44359");
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowCredentials();
        options.WithExposedHeaders(ExposedHeaders);
    });
});


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
