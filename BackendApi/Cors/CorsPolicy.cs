namespace BackendApi.Cors
{
    public static class CorsPolicy
    {
        public static void AddCustomCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500", "https://another-site.com")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }


    }
}
