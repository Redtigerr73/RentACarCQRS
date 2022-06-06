using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Threading.Tasks;
using WebUI.MVC.Services.Implementation;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC
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
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddHttpClient<IBookingService, BookingServiceImp>();
            services.AddTransient<IBookingService, BookingServiceImp>();
            services.AddTransient<IUserManagement, UserManagementImp>();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie()
            .AddOpenIdConnect("Auth0", option =>
            {
                //Define the autority
                option.Authority = $"https://{Configuration["Auth0:Domain"]}";
                option.ClientId = Configuration["Auth0:ClientId"];
                option.ClientSecret = Configuration["Auth0:ClientSecret"];
                //Authorization Code
                option.ResponseType = OpenIdConnectResponseType.Code;
                //Define the need scope
                option.Scope.Clear();
                option.Scope.Add("openid");
                option.Scope.Add("profile");
                option.Scope.Add("read:bookings");
                option.Scope.Add("write:bookings");
                option.Scope.Add("delete:bookings");                
                //define callback 
                option.CallbackPath = new PathString("/callback");
                option.SaveTokens = true;
                option.ClaimsIssuer = "Auth0";
                //Add events for logout (and maybe more ;-))
                option.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }
                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();
                        return Task.CompletedTask;
                    },
                    OnRedirectToIdentityProvider = context =>
                    {
                        context.ProtocolMessage.SetParameter("audience", Configuration["Auth0:Audience"]);
                        return Task.FromResult(0);
                    },

                    OnMessageReceived = context =>
                    {
                        if (context.ProtocolMessage.Error == "access_denied")
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Bookings/AccessDenied");

                        }
                        return Task.FromResult(0);
                    }
                   
                };
            });


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCookiePolicy();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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