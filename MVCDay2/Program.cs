namespace MVCDay2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            options.IdleTimeout = TimeSpan.FromDays(1));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use(async (context, next) =>
            {
                if (context.Request.Cookies.ContainsKey("ReqNum"))
                {
                    
                    int num = int.Parse(context.Request.Cookies["ReqNum"]);
                    context.Response.Cookies.Append("ReqNum", (++num).ToString());
                    if (num>=1&&num <= 10)
                    {
                        context.Response.Cookies.Append("stars", "1");
                    }else if (num >= 11 && num <= 20)
                    {
                        context.Response.Cookies.Append("stars", "2");
                    }
                    else if (num >= 21 && num <= 30)
                    {
                        context.Response.Cookies.Append("stars", "3");
                    }
                    else if (num >= 31 && num <= 40)
                    {
                        context.Response.Cookies.Append("stars", "4");
                    }
                    else if (num >=41)
                    {
                        context.Response.Cookies.Append("stars", "5");
                    }
                }
                else
                {
                    context.Response.Cookies.Append("ReqNum", "1");
                }
                await next();
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}/{secid?}");

            app.Run();
        }
    }
}