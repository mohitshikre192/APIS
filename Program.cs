using APIS.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;

using System.Text;
var jwt = System.Configuration.ConfigurationManager.GetSection("JwtSettings");

var builder = WebApplication.CreateBuilder(args);
//var key = [a-quick-brown-fox-jumps-over-a-lazy-dog];
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer( x=>
{
    // object config = null;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey 
                              (Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
       ValidateLifetime=true,
       ValidateIssuerSigningKey=true
    };
});

builder.Services.AddAuthentication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup  =>
    { 
    var jwtSecurityScheme = new OpenApiSecurityScheme
{
    BearerFormat = "JWT",
    Name = "JWT Authentication",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = JwtBearerDefaults.AuthenticationScheme,
    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

    Reference = new OpenApiReference
    {
        Id = JwtBearerDefaults.AuthenticationScheme,
        Type = ReferenceType.SecurityScheme
    }
};

setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AppConn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});