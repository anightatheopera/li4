using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Syncfusion.Blazor;
using DataAccessLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IUtilizadoresData, UtilizadoresData>();
builder.Services.AddTransient<IFeirasData, FeirasData>();
builder.Services.AddTransient<IBarracasData, BarracasData>();
builder.Services.AddTransient<IProdutosData, ProdutosData>();
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
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=mercadum.database.windows.net;Initial Catalog=MercadUM;User ID=mercadum;Password=Grupo#8UM;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(cs);

            string query = "select * from [dbo].[utilizadores]";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            con.Close();
        }
    }
}
