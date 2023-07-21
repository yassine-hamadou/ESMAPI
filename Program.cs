using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceManagerApi.ActivityLog;
using ServiceManagerApi.Data;
using ServiceManagerApi.Helpers;
using ServiceManagerApi.Models;
using ServiceManagerApi.UserModels;


var builder = WebApplication.CreateBuilder(args);


// builder.WebHost.ConfigureKestrel(options => { });
var SMconnectionString = builder.Configuration.GetConnectionString("ServiceManagerConnection");
builder.Services.AddDbContext<ServiceManagerContext>(options =>
    options.UseSqlServer(SMconnectionString));


var EnPconnectionString = builder.Configuration.GetConnectionString("EnpConnectionString");
var UserDbConnection = builder.Configuration.GetConnectionString("UserDbConnection");

builder.Services.AddDbContext<EnpDbContext>(options => options.UseSqlServer(EnPconnectionString));
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(UserDbConnection));

//builder.Services.AddScoped<ActivityLog>();
//this will allow for patch request
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddControllers(options => { options.Filters.Add(typeof(ActivityLog)); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);

builder.Services.AddCors();

var app = builder.Build();

//cors configuration for 
app.UseCors(
    options =>
    {
      var frontendUrl = "http://localhost:3000";
      var serverUrl = "http://208.117.44.15/";
      var sipserver = "https://app.sipconsult.net/";
      var sipserver2 = "http://app.sipconsult.net";
      // options.WithOrigins(frontendUrl, serverUrl, sipserver, sipserver2)
      //     .AllowAnyHeader()
      //     .AllowAnyMethod();
      options.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
    });

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// }

app.UseSwagger();
app.UseSwaggerUI();
// else
// {
//   app.UseSwagger();
//   app.UseSwaggerUI(c => { c.SwaggerEndpoint("/SmWebApi/swagger/v1/swagger.json", "ESMS API V1"); });
// }


// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();