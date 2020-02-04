using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GraduateNotes.RT.Realtime;
using Hangfire;
using Hangfire.MySql;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraduateNotes.RT
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //GlobalConfiguration.Configuration.UseStorage(
            //    new MySqlStorage(Configuration.GetConnectionString("HangfireMySqlConnection"),
            //    new MySqlStorageOptions
            //    {
            //        TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
            //        QueuePollInterval = TimeSpan.FromSeconds(15),
            //        JobExpirationCheckInterval = TimeSpan.FromHours(1),
            //        CountersAggregateInterval = TimeSpan.FromMinutes(5),
            //        PrepareSchemaIfNecessary = true,
            //        DashboardJobListLimit = 50000,
            //        TransactionTimeout = TimeSpan.FromMinutes(1),
            //        TablesPrefix = "Hangfire"
            //    })
            //);

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                //.UseSqlServerStorage(Configuration.GetConnectionString("MySqlHangfire"), 
                //new SqlServerStorageOptions
                //{
                //    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                //    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                //    QueuePollInterval = TimeSpan.Zero,
                //    UseRecommendedIsolationLevel = true,
                //    UsePageLocksOnDequeue = true,
                //    DisableGlobalLocks = true
                //})
                .UseStorage(
                    new MySqlStorage(Configuration.GetConnectionString("HangfireMySqlConnection"),
                    new MySqlStorageOptions
                    {
                        TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                        QueuePollInterval = TimeSpan.FromSeconds(15),
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        PrepareSchemaIfNecessary = true,
                        DashboardJobListLimit = 50000,
                        TransactionTimeout = TimeSpan.FromMinutes(1),
                        TablesPrefix = "Hangfire"
                    })
                )
            );

            // Add the processing server as IHostedService
            services.AddHangfireServer();
            services.AddSignalR(options => options.EnableDetailedErrors = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseHangfireDashboard();

            app.UseSignalR(routes =>
            {
                routes.MapHub<NotesHub>("/chathub");
            });

            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}
