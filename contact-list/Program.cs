using Microsoft.EntityFrameworkCore;
using ContactsList.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ContactsList.Data.Db>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))); // Add this line to register the DbContext
builder.Services.AddScoped<ContactsList.Repository.IContactsRepo, ContactsList.Repository.ContactsRepo>(); // Add this line to register the SubjectsRepo

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
