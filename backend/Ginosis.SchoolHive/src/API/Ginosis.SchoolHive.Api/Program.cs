using Ginosis.Common.Application;
using Ginosis.Common.Application.Behaviors;
using Ginosis.Common.Infrastructure;
using Ginosis.SchoolHive.Api.Extensions;
using Ginosis.SchoolHive.Api.Middleware;
using SchoolHive.Modules.Users.Application;
using SchoolHive.Modules.Users.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(AssemblyReference.Assembly);
    config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
});

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddUsersModule(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication([AssemblyReference.Assembly]);
//Global Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddInfrastructure(databaseConnectionString);

builder.Configuration.AddModuleConfiguration(["users"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
