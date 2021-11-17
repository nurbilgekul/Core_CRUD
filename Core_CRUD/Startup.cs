using Core_CRUD.Infrastructure.Context;
using Core_CRUD.Infrastructure.Repositories.Concrete;
using Core_CRUD.Infrastructure.Repositories.Interface;
using Core_CRUD.Models.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD
{
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
            //Build-in IoC container burada y�netiliyor.
            //IoC container i�erisinde ba��ml��a neden olacak servislerimizi inject ediyoruz. Yani uygulama i�erisinde ba��ml�l��a neden oalcak s�n�flar� buraya register yada resolve ediyoruz. Basit bir �rnek vermek gererkirse standart .net te yapt���m�z �rnekte ProjectContext.cs s�n�f�m�z� new'lemi�tik. Art�k new'lemek yerine buraya registe redece�iz ve ihtiyac�m�z olan yerde DI kullanarak inject edece�iz� B�ylelelike ba��ml�l�klar� bir nebze olsun k�raca��z. Ba�ka bir �rnek vermek gerekirse, standartr .net'te repository'lerimizi ihtiya� duydu�umuz yerlerde concretelerini new'leyerek kullan�yorduk. Art�k burada interface ve conrete aras�ndaki ili�kiyi buraya resolve edece�iz. B�ylelikle herhangi bir repository ihtiya� duydu�umuz yerde interface'sini inject etti�imizde uygulama bize hangi concrete teslim edece�ini bilecek.
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IBaseRepository<Category>, CategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
