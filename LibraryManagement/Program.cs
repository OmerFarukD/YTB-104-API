using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Middlewares;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.BusinessRules;
using LibraryManagement.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<ExceptionHandlerConfig>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC Kayıtları

// Dependency Injection LifeCycle 
// AddScopped() : Her bir Http isteği Response a dönene kadar 1 tane nesne üretir.


// AddSingleton() : Uygulama ayakta olduğu sürece 1 tane nesne üretir.


// AddTransiesnt(): Her bir istek başına 1 tane nesne üretir.

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<BaseDbContext>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddScoped<BookBusinessRules>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(_=> { });

app.MapControllers();

app.Run();
