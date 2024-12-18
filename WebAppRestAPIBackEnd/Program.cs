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

// Szolg�ltat�sok regisztr�l�sa
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI �s API be�ll�t�sok
app.UseSwagger();
app.UseSwaggerUI();

// Authorization middleware
app.UseAuthorization();

// API v�gpontok lek�pez�se
app.MapControllers();

// Az API-t minden h�l�zati interf�szen el�rhet�v� teszi
app.Urls.Add("http://0.0.0.0:5243");  // Ezzel minden interf�szen el�rhet�v� v�lik az API

app.Run();
