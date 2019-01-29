using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HT.Sports.UI.Web.External
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // When the app runs in the Development environment:
                //   Use the Developer Exception Page to report app runtime errors.
                //   Use the Database Error Page to report database runtime errors.
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // When the app doesn't run in the Development environment:
                //   Enable the Exception Handler Middleware to catch exceptions
                //app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePages();

            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            //app.UseHttpsRedirection();

            // Return static files and end the pipeline.
            app.UseStaticFiles();

            // Use Cookie Policy Middleware to conform to EU General Data 
            // Protection Regulation (GDPR) regulations.
            //app.UseCookiePolicy();

            // Authenticate before the user accesses secure resources.
            //app.UseAuthentication();

            // If the app uses session state, call Session Middleware after Cookie 
            // Policy Middleware and before MVC Middleware.
            //app.UseSession();

            // Add MVC to the request pipeline.
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
