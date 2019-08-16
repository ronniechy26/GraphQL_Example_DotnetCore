using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQL_Example.DataAccessLayer.Implementation;
using GraphQL_Example.DataAccessLayer.Repository;
using GraphQL_Example.Database;
using GraphQL_Example.Database.Models;
using GraphQL_Example.Mutations;
using GraphQL_Example.Queries;
using GraphQL_Example.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraphQL_Example
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContextPool<AppDbContext>(options => 
                                                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                                    b => b.MigrationsAssembly("GraphQL_Example")));

            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<AppUserQuery>();
            services.AddSingleton<AppUserMutation>();
            services.AddSingleton<AppUserType>();
            services.AddSingleton<AppUserInputType>();
            services.AddSingleton<TransactionType>();
            ServiceProvider sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQL_Example.Schema.Schema(new FuncDependencyResolver(type => sp.GetService(type))));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,AppDbContext appDb)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphiQl("/api/graphql");
            appDb.Database.EnsureCreated();
            appDb.Seed();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
