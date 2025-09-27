var builder = WebApplication.CreateBuilder(args);//crea un constructor de aplicaciones

// Add services to the container.
builder.Services.AddControllersWithViews();//agrega servicios de controladores con vistas (MVC)
//configurar un cliente HTTP para comunicarse con la API AsistMedAPI
builder.Services.AddHttpClient("AsistMedAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiUrls:AsistMedAPI"]);//URL base de la API
    
});

var app = builder.Build();//crea una instancia de la web

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

app.Run();//inicia la aplicacion
