using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
/*
builder.Services.AddSwaggerGen(options => {
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "openapi.json"));
});

builder.Services.UseContactsApi();
builder.Services.AddSwaggerGen(c=>{
    c.SwaggerDoc("v1",
    new() { Title= "MyPage", Version = "v1"});
});
*/

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options => 
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

/*
app.MapGet("/", () => "Hello World!");
app.MapContactsApi();
app.UseSwaggerUI(c=> c.SwaggerEndpoint(
    "/swagger/v1/swagger.json",
    "v1"
));
*/

app.Run();
