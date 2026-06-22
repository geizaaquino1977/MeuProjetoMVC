using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uc_4_Antonia_Clinica.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Uc_4_Antonia_ClinicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Uc_4_Antonia_ClinicaContext") ?? throw new InvalidOperationException("Connection string 'Uc_4_Antonia_ClinicaContext' not found.")));

// Add services to the container.



builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ✅ aqui

app.UseAuthorization();



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

app.UseSession(); // ✅ aqui

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
