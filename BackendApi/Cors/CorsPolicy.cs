namespace BackendApi.Cors
{
    public static class CorsPolicy
    {
        public static void AddCustomCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("HomologPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });

                options.AddPolicy("ProductionPolicy", policy =>
                {
                    policy.WithOrigins()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }


    }
}
