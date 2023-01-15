using MercadUM.Areas.Identity;
using MercadUM.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MercadUM.SqlDataAccess;
using Syncfusion.Blazor;
using MercadUM.Model;
using MercadUM.Areas.Feiras.Pages.Manage;
using Microsoft.Data.SqlClient;
using MercadUM.Areas.Identity.Pages.Account;
using MercadUM.Areas.Barracas.Pages.Manage;
using MercadUM.Areas.Produtos.Pages.Manage;
using Smart.Blazor;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => { 
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = false; 
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders(); 
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IRegisterModel, RegisterModel>();
builder.Services.AddTransient<IAdicionarBarracaModel,AdicionarBarracaModel>();
builder.Services.AddTransient<IAdicionarFeiraModel,AdicionarFeiraModel>();
builder.Services.AddTransient<IAdicionarProdutoModel,AdicionarProdutoModel>();
builder.Services.AddTransient<IUserAccess, UserAccess>();
builder.Services.AddTransient<IImageHandler, AdicionarProdutoModel.ImageHandler>();
builder.Services.AddSmart();
builder.Services.AddSyncfusionBlazor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

namespace MercadUM
{
    class Program { 
    static void Main(string[] args)
        {
            string cs = "Data Source=mercadum.database.windows.net;Initial Catalog=MercadUM;User ID=mercadum;Password=Grupo#8UM;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(cs);

            con.Open();
            Console.WriteLine("Conectado");
            con.Close();
        }
    }
}
