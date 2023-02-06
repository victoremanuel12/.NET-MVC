using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC2022.Context;
using MVC2022.Controllers;
using MVC2022.Models;
using MVC2022.Repositories;
using MVC2022.Repositories.Interfaces;
using MVC2022.Services;

namespace LanchesMac;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        // addTtransient a cada requisição um novo serviço é criado,mantem algum estado entre os requisitantes 
        services.AddTransient<ILanchesRepository,LancheRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient <IPedidoRepository,PedidoRepository>();
        //instanciado apenas uma vez, e apos isso a mesma instancia será utilizada
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // addScoped adiciona um seviço dentro do escopo da requisição, o 1 que solicitar/acionar o servico receber o serviço porem o segundo que solicitar,
        // vai receber o mesmo serviço criado anteriormente,em outra requisição terá uma nova isntancia do serviço
        services.AddScoped(sp => CarrinhoCompra.GetCarrinhoCompra(sp));

        services.AddScoped<ISeedUserRoleInitial, SeedRoleInitial>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", politica =>
            {
                politica.RequireRole("Admin");
            });
        });
        services.AddControllersWithViews();
        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
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
        //Cria perfies
        seedUserRoleInitial.SeedRoles();
        //cria os usuarios e atribui ao perfil 
        seedUserRoleInitial.SeedUsers();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();
        // Rotas com EndPoint da aplicação
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
            );
            endpoints.MapControllerRoute(
                    name: "categoriaFiltro",
                    pattern: "Lanche/{action}/{categoria?}",
                    defaults: new { Controller = "Lanche", action = "List" }
             );
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
         }  );
    }
}
