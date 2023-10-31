using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudyCenter.Backend.DataLayer;
using StudyCenter.Backend.Repositories.Account;
using StudyCenter.Backend.Repositories.StudyRepository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStudyService, StudyService>();

builder.Services.AddScoped<IAdminAccountService, AdminAccountService>();

builder.Services.AddDbContext<StudyDbContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("StudyConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//dastur ishlaganda xatolik xabarini berish
app.UseExceptionHandler(
    option =>
    {
        option.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    await context.Response.WriteAsync(ex.Error.Message);

                }
            });
    }
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
