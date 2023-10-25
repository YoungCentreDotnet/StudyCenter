using Microsoft.EntityFrameworkCore;
using StudyCenter.Backend.DataLayer;
using StudyCenter.Backend.Repositories.AccountRepository.Admin;
using StudyCenter.Backend.Repositories.StudyRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IStudyService, StudyService>();

builder.Services.AddDbContext<StudyDbContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("StudyConnectionString")));

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
