using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Antinew.AspNetCore3._1.Demo.Middleware;
using Antinew.AspNetCore3._1.Demo.Utility;
using Antinew.AspNetCore3._1.Implement;
using Antinew.AspNetCore3._1.Interface;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Antinew.AspNetCore3._1.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        /// <summary>
        /// ��ʼ��IOC����
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.BuildServiceProvider().GetService
            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add<CustomExceptionFilterAttribute>(); // ȫ��ע�ᣬÿ��controller
                    options.Filters.Add<CustomGlobalFilterAttribute>();
                }
                );
            services.AddSession();

            services.AddScoped(typeof(CustomExceptionFilterAttribute)); // �������ɣ��Զ�ע��
            services.AddScoped<ITestServiceA, TestServiceA>();
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
            => containerBuilder.RegisterModule<CustomAutofacModule>();

        /// <summary>
        /// ��ʼ���м�� AOPʽ��
        /// �м��Invoke��HttpContext��-��ResourceFilterִ��ǰ-��ȫ��Filterִ��ǰ-��������ִ��ǰ-��Actionִ��ǰ-��{Action�еĴ��루OnActionExecut��|��ͼ��OnResultExecut��}-��Actionִ�к�-��������ִ�к�-��ȫ��Filterִ�н���-��ResourceFilterִ�к�(Ȼ����Ⱦ��ͼ)-���м��next��RequestDelegate��
        /// Filter OrderĬ����0����С����Ĭ��ִ��
        /// FilterContext.Result�ĸ�ֵ�����ж�����
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.�����󼶣�
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region �ж�ʽ�м��
            //app.Run(context => context.Response.WriteAsync("hollow"));
            //app.Use(_ => context => context.Response.WriteAsync("hollow")); // ��ͬ����
            #endregion

            #region Use�м��
            //app.Use(next =>
            //{
            //    Console.WriteLine("middle1");
            //    return new RequestDelegate(
            //           async context =>
            //           {
            //               await context.Response.WriteAsync("hollow.... start1\n");
            //               await next.Invoke(context);
            //               await context.Response.WriteAsync("hollow.... end1\n");
            //           });
            //});
            //app.Use(next =>
            //{
            //    Console.WriteLine("middle2");
            //    return new RequestDelegate(
            //           async context =>
            //           {
            //               await context.Response.WriteAsync("hollow.... start2\n");
            //               await next.Invoke(context);
            //               await context.Response.WriteAsync("hollow.... end2\n");
            //           });
            //});
            //app.Use(next =>
            //{
            //    Console.WriteLine("middle3");
            //    return new RequestDelegate(
            //           async context =>
            //           {
            //               await context.Response.WriteAsync("hollow.... start3\n");
            //               await context.Response.WriteAsync("hollow.... end3\n");
            //           });
            //});
            #endregion


            // UseWhen
            app.UseWhen(
                context => context.Request.Query.ContainsKey("Name"),
                builder => builder.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Hellow~~~~~~");
                    //await next();
                }));
            // Map
            app.Map("/antinew", builder => builder.Run(async request => await request.Response.WriteAsync("this is antinew page")));

            // MapWhen
            app.MapWhen(context => context.Request.Query.ContainsKey("Age"), b => b.UseWhen(
                 context => context.Request.Query.ContainsKey("ss"),
                 builder => builder.Use(async (context, next) =>
                 {
                     await context.Response.WriteAsync("Hellow2~~~~~~");
                    //await next();
                })));

            // UseMiddleware
            app.UseMiddleware<ExceptionMiddleware>();

            #region ����
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
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles(
                new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
                }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
        }

        //public RequestDelegate Build()
        //{
        //    RequestDelegate app = context =>
        //    {
        //        // If we reach the end of the pipeline, but we have an endpoint, then something unexpected has happened.
        //        // This could happen if user code sets an endpoint, but they forgot to add the UseEndpoint middleware.
        //        var endpoint = context.GetEndpoint();
        //        var endpointRequestDelegate = endpoint?.RequestDelegate;
        //        if (endpointRequestDelegate != null)
        //        {
        //            var message =
        //                $"The request reached the end of the pipeline without executing the endpoint: '{endpoint.DisplayName}'. " +
        //                $"Please register the EndpointMiddleware using '{nameof(IApplicationBuilder)}.UseEndpoints(...)' if using " +
        //                $"routing.";
        //            throw new InvalidOperationException(message);
        //        }

        //        context.Response.StatusCode = 404;
        //        return Task.CompletedTask;
        //    };

        //    foreach (var component in _components.Reverse())
        //    {
        //        app = component(app);
        //    }

        //    return app;
        //}
    }
}