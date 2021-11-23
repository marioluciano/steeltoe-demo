var builder = WebApplication.CreateBuilder(args);

// Add Steeltoe actuators.
builder.Host.AddHealthActuator();
builder.Host.AddInfoActuator();
builder.Host.AddLoggersActuator();

// Add Steeltoe dynamic logging.
builder.Host.AddDynamicLogging();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Steeltoe distributed tracing.
builder.Services.AddDistributedTracing();

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
