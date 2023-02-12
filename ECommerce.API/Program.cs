var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext Service
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
opt.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("defaultConnection")), ServiceLifetime.Singleton);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddJsonOptions(opt => 
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();

