namespace MyBlog.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyBlog.Data;
    using MyBlog.Models.Users;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using AspNet.Security.OAuth.GitHub;
    using MyBlog.App.Areas.Identity.Services;
    using AutoMapper;
    using MyBlog.App.Common;
    using Microsoft.AspNetCore.Authentication.Facebook;
    using MyBlog.Services;
    using MyBlog.Services.AdminServices;
    using MyBlog.Services.Interfaces;
    using MyBlog.Services.AdminServices.Interfaces;
    using MyBlog.Services.OwnerServices.Interfaces;
    using MyBlog.Services.OwnerServices;
    using MyBlog.Services.PremiumServices.Interfaces;
    using MyBlog.Services.PremiumServices;

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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //services.AddDbContext<BlogDataDbContext>();

            services.AddDbContext<BlogDataDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyBlogConnection")));

            services
                .AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<BlogDataDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                options.Lockout.MaxFailedAccessAttempts = 4;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);

                //options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddAutoMapper();

            services.AddAuthentication()
                .AddFacebook(fb =>
                {
                    fb.AppId = this.Configuration["Authentication:Facebook:AppId"];
                    fb.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });

            services.Configure<FacebookOptions>(fb =>
            {
                fb.AppId = this.Configuration.GetSection("Authentication:Facebook:AppId").Value;
                fb.AppSecret = this.Configuration.GetSection("Authentication:Facebook:AppSecret").Value;
            });

            services.AddAuthentication()
                .AddGoogle(google =>
                {
                    google.ClientId = this.Configuration["Authentication:Google:ClientId"];
                    google.ClientSecret = this.Configuration["Authentication:Google:ClientSecret"];
                });
            
            services.AddSingleton<IEmailSender, SendGridEmailSender>();

            services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

            RegisterServiceLayer(services);

            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.SeedDatabase();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IJokeService, JokeService>();
            services.AddScoped<IMemeService, MemeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<IOwnerUserService, OwnerUserService>();
            services.AddScoped<IPremiumProductService, PremiumProductService>();
        }
    }
}
