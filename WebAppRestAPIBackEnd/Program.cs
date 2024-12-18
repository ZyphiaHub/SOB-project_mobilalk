//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

var builder = WebApplication.CreateBuilder(args);

// Szolgáltatások regisztrálása
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI és API beállítások
app.UseSwagger();
app.UseSwaggerUI();

// Authorization middleware
app.UseAuthorization();

// API végpontok leképezése
app.MapControllers();

// Az API-t minden hálózati interfészen elérhetõvé teszi
app.Urls.Add("http://0.0.0.0:5243");  // Ezzel minden interfészen elérhetõvé válik az API

app.Run();
