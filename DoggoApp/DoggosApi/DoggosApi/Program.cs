using DoggosApi.Data;
using DoggosApi.Interface;
using DoggosApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

var builder = WebApplication.CreateBuilder(args);
var MyOrigins = "_myOrigins";

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<UuidGenerator>();
builder.Services.AddTransient<DatabaseInit>();
builder.Services.AddTransient<IJsonValidateService, JsonValidateService>();
builder.Services.AddTransient<ApiDataProvider>();
builder.Services.AddTransient<IDataConversionService, DataConversionService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        }
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.UseCors(MyOrigins);

app.Run();
