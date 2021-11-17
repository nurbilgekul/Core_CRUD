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
            //Build-in IoC container burada yönetiliyor.
            //IoC container içerisinde baðýmlýða neden olacak servislerimizi inject ediyoruz. Yani uygulama içerisinde baðýmlýlýða neden oalcak sýnýflarý buraya register yada resolve ediyoruz. Basit bir örnek vermek gererkirse standart .net te yaptýðýmýz örnekte ProjectContext.cs sýnýfýmýzý new'lemiþtik. Artýk new'lemek yerine buraya registe redeceðiz ve ihtiyacýmýz olan yerde DI kullanarak inject edeceðizç Böylelelike baðýmlýlýklarý bir nebze olsun kýracaðýz. Baþka bir örnek vermek gerekirse, standartr .net'te repository'lerimizi ihtiyaç duyduðumuz yerlerde concretelerini new'leyerek kullanýyorduk. Artýk burada interface ve conrete arasýndaki iliþkiyi buraya resolve edeceðiz. Böylelikle herhangi bir repository ihtiyaç duyduðumuz yerde interface'sini inject ettiðimizde uygulama bize hangi concrete teslim edeceðini bilecek.
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
