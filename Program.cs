using Elfie.Serialization;
using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Helpers;
using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<FileUploadHelper>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MaiamtruyentinContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDangKyTinhNguyenService, DangKyTinhNguyenService>();
builder.Services.AddScoped<IGioiThieuService, GioiThieuService>();
builder.Services.AddScoped<ILichSuKienService, LichSuKienService>();
builder.Services.AddScoped<ITinTucService, TinTucService>();
builder.Services.AddScoped<INhaTaiTroService, NhaTaiTroService>();

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
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
