using HelloMvc.Data;
using HelloMvc.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IEmployeeRepo, EmployeeMockRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

var connectionString = builder.Configuration.GetConnectionString("EmployeeDb");

builder.Services.AddDbContext<EmployeeContext>(o => {
    o.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//
app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();



app.MapControllerRoute(
    name: "blog",
    pattern: "{year:length(4)}/{month:int}/{day:int}",
    defaults: new { controller = "Blog", action = "Index" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
