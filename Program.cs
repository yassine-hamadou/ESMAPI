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

builder.Services.AddCors(options =>
    {
      options.AddDefaultPolicy(builderIn =>
          {
            builderIn.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
          }
      );
    }
);

var app = builder.Build();

app.UseCors();
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
